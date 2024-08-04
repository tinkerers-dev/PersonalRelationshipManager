﻿using FluentAssertions;
using JetBrains.Annotations;
using Moq;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Application.UseCases;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Repositories;
using PersonalRelationshipManager.Shared;
using PersonalRelationshipManager.Tests.Builders;

namespace PersonalRelationshipManager.Tests.Relationships.Application.UseCases;

[TestSubject(typeof(CreateRelationshipUseCase))]
public class CreateRelationshipUseCaseShould
{
    private Mock<IRelationshipRepository> _relationshipRepository;
    private Mock<IGuidService> _guidService;
    private CreateRelationshipUseCase _useCase;

    public CreateRelationshipUseCaseShould()
    {
        _relationshipRepository = new Mock<IRelationshipRepository>();
        _guidService = new Mock<IGuidService>();
        _useCase = new CreateRelationshipUseCase(_relationshipRepository.Object, _guidService.Object);
    }

    [Fact]
    public void CreateRelationshipAndSaveItToDatabase()
    {
        var id = Guid.NewGuid();
        _guidService.Setup(service => service.RandomGuid()).Returns(id);
        var createRelationshipDto = CreateRelationshipDtoBuilder.AFriend().Build();

        _ = _useCase.Execute(createRelationshipDto);

        _relationshipRepository.Verify(repository =>
            repository.SaveRelationship(It.Is<Relationship>(r => r.GetId().Value.Equals(id))));
    }

    [Fact]
    public async Task ReturnSuccessResultWithRelationshipIfRelationshipCreatedAndSavedToDatabase()
    {
        var id = Guid.NewGuid();
        _guidService.Setup(service => service.RandomGuid()).Returns(id);
        var createRelationshipDto = CreateRelationshipDtoBuilder.AFriend().Build();

        var result = await _useCase.Execute(createRelationshipDto);

        result.IsSuccess().Should().BeTrue();
        result.Value.Should().BeOfType<Relationship>().Which.GetId().Value.Should().Be(id);
    }
}