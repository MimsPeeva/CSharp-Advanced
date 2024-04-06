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
        private List<Influencer> influencersData;
        private InfluencerRepository influencerRepository;
        [SetUp]
        public void Setup()
        {
            influencersData = new List<Influencer>();
            influencer = new Influencer(name, followers);
            influencerRepository = new InfluencerRepository();
        }

        [Test]
        public void Constructor_Works_HappyPath()
        {
            influencer = new Influencer(name, followers);
            Assert.IsNotNull(influencer);
            Assert.AreEqual(influencer.Followers,followers);
            Assert.AreEqual(influencer.Username,name);
        }
        [Test]
        public void RegisterInfluencer_ThrowsEx()
        {
            Influencer nullInfluencer = null;
            Assert.AreEqual(influencerRepository.Influencers.Count, 0);
         Assert.Throws<ArgumentNullException>(() => {influencerRepository.RegisterInfluencer(nullInfluencer); });
        }

        [Test]
        public void AlreadyAddedInfluencer_ThrosEx()
        {
           // influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                influencerRepository.RegisterInfluencer(influencer);
            });
        }
        [Test]
        public void Register_HappyPath()
        {
            string expected = $"Successfully added influencer Asq with 20000";
            string actual = influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }
        [Test]
        public void RemoveMethod_NullInfluencer_ThrowsEx()
        {
            string nullUsername = null;
            influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(nullUsername));
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }
        [Test]
        public void RemoveInfluencer_ThrowsEx()
        {
            string username = " ";
            influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(influencerRepository.Influencers.Count,1);
            Assert.Throws<ArgumentNullException>(() => influencerRepository.RemoveInfluencer(username));
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }
        [Test]
        public void RemoveReturnsTrue_HappyPath()
        {
            string usernameExisting = "Asq";
            influencerRepository.RegisterInfluencer(influencer);
            bool result = influencerRepository.RemoveInfluencer(usernameExisting);
            Assert.IsTrue(result);
            Assert.AreEqual(influencerRepository.Influencers.Count, 0);
        }
        [Test]
        public void RemoveReturnsFalse_HappyPath()
        {
            string noExistUsername = "Goshoo";
            influencerRepository.RegisterInfluencer(influencer);
            bool result = influencerRepository.RemoveInfluencer(noExistUsername);
            Assert.IsFalse(result);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }
        [Test]
        public void InfluencerTheMostFollowers_HappyPath()
        {
            Influencer SmallestFollowersinfluencer = new Influencer("Sonq", 3);
            Influencer MiddestFollowersinfluencer = new Influencer("Didi", 450);
            Influencer BiggestFollowersinfluencer = new Influencer("Xixi", 300000);
            influencerRepository.RegisterInfluencer(SmallestFollowersinfluencer);
            influencerRepository.RegisterInfluencer(MiddestFollowersinfluencer);
            influencerRepository.RegisterInfluencer(BiggestFollowersinfluencer);

            Influencer returnedInfluencer = influencerRepository.GetInfluencerWithMostFollowers();
            Assert.That(returnedInfluencer, Is.Not.Null);
            Assert.AreEqual(returnedInfluencer.Username, "Xixi");
            Assert.AreEqual(returnedInfluencer.Followers, 300000);
            Assert.AreEqual(returnedInfluencer, BiggestFollowersinfluencer);
        }
        [Test]
        public void GetInfluencer_ByName_HappyPath()
        {
            Influencer firstInfluencer = new Influencer("Gosho", 20);
            Influencer secondInfluencer = new Influencer("Petya", 50);
            Influencer thirdInfluencer = new Influencer("Asq", 300);
            influencerRepository.RegisterInfluencer(firstInfluencer);
            influencerRepository.RegisterInfluencer(secondInfluencer);
            influencerRepository.RegisterInfluencer(thirdInfluencer);
            string validName = "Gosho";

            Influencer returnedInfluencer = influencerRepository.GetInfluencer(validName);
            Assert.That(returnedInfluencer, Is.Not.Null);
            Assert.AreEqual(returnedInfluencer.Username, "Gosho");
            Assert.AreEqual(returnedInfluencer.Followers, 20);
            Assert.AreEqual(returnedInfluencer, firstInfluencer);
        }
    }
}