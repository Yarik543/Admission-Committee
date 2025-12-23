using System;
using System.Collections.Generic;
using AdmissionCommittee.Abstractions.Repositories;
using AdmissionCommittee.Domain.Entities;
using AdmissionCommittee.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace AdmissionCommittee.Tests
{
    public class ApplicantServiceTests
    {
        private readonly Mock<IApplicantRepository> _repositoryMock;
        private readonly ApplicantService _service;

        public ApplicantServiceTests()
        {
            _repositoryMock = new Mock<IApplicantRepository>();
            _service = new ApplicantService(_repositoryMock.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnApplicantsFromRepository()
        {
            var applicants = new List<Applicant>
            {
                new Applicant(),
                new Applicant()
            };

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(applicants);

            var result = _service.GetAll();

            result.Should().BeEquivalentTo(applicants);
        }

        [Fact]
        public void Add_ShouldCallRepositoryAdd()
        {
            var applicant = new Applicant();

            _service.Add(applicant);

            _repositoryMock.Verify(
                r => r.Add(applicant),
                Times.Once);
        }

        [Fact]
        public void Update_ShouldCallRepositoryUpdate()
        {
            var applicant = new Applicant();

            _service.Update(applicant);

            _repositoryMock.Verify(
                r => r.Update(applicant),
                Times.Once);
        }

        [Fact]
        public void Remove_ShouldCallRepositoryRemove()
        {
            var id = Guid.NewGuid();

            _service.Remove(id);

            _repositoryMock.Verify(
                r => r.Remove(id),
                Times.Once);
        }

        [Fact]
        public void CountAll_ShouldReturnApplicantsCount()
        {
            var applicants = new List<Applicant>
            {
                new Applicant(),
                new Applicant(),
                new Applicant()
            };

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(applicants);

            var count = _service.CountAll();

            count.Should().Be(3);
        }

        [Fact]
        public void CountPassed_ShouldCountApplicantsAboveMinScore()
        {
            var applicants = new List<Applicant>
            {
                new Applicant { MathScore = 30, RusScore = 30, ITScore = 30 },
                new Applicant { MathScore = 20, RusScore = 20, ITScore = 20 }
            };

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(applicants);

            var result = _service.CountPassed(70);

            result.Should().Be(1);
        }

        [Fact]
        public void CountPassed_ShouldReturnZero_WhenNobodyPassed()
        {
            var applicants = new List<Applicant>
            {
                new Applicant { MathScore = 10, RusScore = 10, ITScore = 10 },
                new Applicant { MathScore = 15, RusScore = 15, ITScore = 15 }
            };

            _repositoryMock
                .Setup(r => r.GetAll())
                .Returns(applicants);

            var result = _service.CountPassed(50);

            result.Should().Be(0);
        }
    }
}