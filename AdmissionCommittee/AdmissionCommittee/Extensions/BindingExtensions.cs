using System;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace AdmissionCommittee.Extensions
{
    public static class BindingExtensions
    {
        public static void BindControl<TControl, TModel, TProperty>(
            this TControl control,
            TModel model,
            Expression<Func<TControl, object>> controlProperty,
            Expression<Func<TModel, TProperty>> modelProperty,
            ErrorProvider? provider = null)
            where TControl : Control
        {
            // берём имя свойства контрола
            var controlPropertyName = GetPropertyName(controlProperty);

            // берём имя свойства модели
            var modelMember = (MemberExpression)modelProperty.Body;
            var modelPropertyName = modelMember.Member.Name;

            var binding = new Binding(
                controlPropertyName,
                model,
                modelPropertyName,
                formattingEnabled: true,
                dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged
            );

            if (provider != null)
            {
                binding.BindingComplete += (s, e) =>
                {
                    if (string.IsNullOrEmpty(e.ErrorText))
                        provider.SetError(control, "");
                    else
                        provider.SetError(control, e.ErrorText);
                };
            }

            control.DataBindings.Add(binding);
        }

        private static string GetPropertyName<TControl>(Expression<Func<TControl, object>> expr)
        {
            // если свойство приводит к object через Convert
            if (expr.Body is UnaryExpression unary && unary.Operand is MemberExpression member1)
                return member1.Member.Name;

            // если простое выражение
            if (expr.Body is MemberExpression member2)
                return member2.Member.Name;

            throw new ArgumentException("Невозможно определить имя свойства");
        }
    }
}
