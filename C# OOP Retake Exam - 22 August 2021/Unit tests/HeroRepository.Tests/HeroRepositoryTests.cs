using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository repo;
    private Hero hero;

    [SetUp]
    public void Initialize()
    {
        repo = new HeroRepository();
        hero = new Hero("doncho", 100);
    }

    [Test]
    public void Ctor_Should_InitializeObject()
    {
        Assert.IsNotNull(new HeroRepository());
    }

    [Test]
    public void Ctor_Should_InitializeObject_Internal_Collection()
    {
        Assert.IsNotNull(new HeroRepository().Heroes);
    }

    [Test]
    public void Create_Throws_Exception_When_Passed_Null_Object()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Create(null));
    }

    [Test]
    public void Create_Throws_Exception_When_Passed_Existing_Hero()
    {
        repo.Create(hero);
        Assert.Throws<InvalidOperationException>(() => repo.Create(hero));
    }

    [Test]
    public void Create_Should_Add_Hero_To_Internal_Collection_If_All_Is_Well()
    {
        Assert.That(repo.Create(hero) == $"Successfully added hero {hero.Name} with level {hero.Level}");
    }

    [Test]
    public void Remove_Should_Throw_Exception_When_Given_Null_Method_Param()
    {
        Assert.Throws<ArgumentNullException>(() => repo.Remove(null));
    }

    [Theory]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    [TestCase("\n\r")]
    [TestCase("\n")]
    public void Remove_Should_Throw_Exception_When_Given_Whitespace_Method_Param(string nullOrWhiteSpace)
    {
        Assert.Throws<ArgumentNullException>(() => repo.Remove(nullOrWhiteSpace));
    }

    [Test]

    public void Remove_Should_Reduce_Count_Of_Internal_Collection()
    {
        repo.Create(hero);

        repo.Remove(hero.Name);

        Assert.False(repo.Heroes.Contains(hero));
    }

    [Test]
    public void Remove_Should_Return_True_When_It_Successfully_Removes_Hero()
    {
        repo.Create(hero);

        Assert.True(repo.Remove(hero.Name));
    }

    [Test]
    public void GetHeroWithHighestLevel_Should_Return_The_Hero_With_The_Highest_Level()
    {
        repo.Create(hero);
        repo.Create(new Hero("Peshko", 1));

        Assert.AreEqual(hero, repo.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero_Should_Return_Hero_With_Given_Name()
    {
        repo.Create(hero);

        Assert.AreEqual(hero, repo.GetHero(hero.Name));
    }

    [Test]
    public void Heroes_Property_Should_Return_Internal_Heroes_Collection()
    {
        var heroes = new List<Hero>();

        heroes.Add(hero);
        repo.Create(hero);

        Assert.AreEqual(heroes,repo.Heroes);
    }
}