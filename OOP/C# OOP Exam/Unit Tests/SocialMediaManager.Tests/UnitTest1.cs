using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private string name="Asq";
        private int followers=20000;
        private Influencer influencer;
        private List<Influencer> influencersList;
        private InfluencerRepository influenInfluencerRepository;
        [SetUp]
        public void Setup()
        {
            influencersList = new List<Influencer>();
        }

        [Test]
        public void Constructor_Works_HappyPath()
        {
            influencer = new Influencer(name, followers);
            Assert.AreEqual(influencer.Followers,followers);
            Assert.AreEqual(influencer.Username,name);
        }

        //[Test]
        //public void Influensers_ReturnCorrectly_NewList()
        //{
        //    influenInfluencerRepository = new InfluencerRepository();
        //    Assert.AreEqual(influenInfluencerRepository,0);
        //}

        [Test]
        public void RegisterInfluencer_HappyPath()
        {
            string expected = $"Successfully added influencer {name} with {followers}";
            influencer = new Influencer(name, followers);

           string acctual = influenInfluencerRepository.RegisterInfluencer(influencer);
            influencersList.Add(influencer);
            Assert.AreEqual(expected, acctual);
                
        }
    }
}