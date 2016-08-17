﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brockhaus.PraktikumZeugnisGenerator.Model;
using System.Text.RegularExpressions;

namespace Brockhaus.PraktikumZeugnisGenerator.Services.Tests
{
    [TestClass]
    public class TestStringEditor
    {
        [TestMethod]
        public void TestReplaceGenderWords_Simple_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<Er/Sie>>";
            string word = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);
            string replaceString = Regex.Match(doctText, @"(<<.*?\/.*?>>)").ToString();

            string ergebnis = doctText.Replace(replaceString, word);
            Assert.AreEqual("Er",ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_Simple_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<Er/Sie>>";
            string word = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);
            string replaceString = Regex.Match(doctText, @"(<<.*?\/.*?>>)").ToString();

            string ergebnis = doctText.Replace(replaceString, word);
            Assert.AreEqual("Sie",ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_OneGenderWordInSentence_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<Er/Sie>> hat gute Arbeit geleistet";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er hat gute Arbeit geleistet", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_OneGenderWordInSentence_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<Er/Sie>> hat gute Arbeit geleistet";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie hat gute Arbeit geleistet",ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_Complete_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;
            internDetails.DateOfBirth = System.DateTime.Now;
            internDetails.UntilDate = System.DateTime.Now;
            internDetails.FromDate = System.DateTime.Now;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_Complete_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;
            internDetails.DateOfBirth = System.DateTime.Now;
            internDetails.UntilDate = System.DateTime.Now;
            internDetails.FromDate = System.DateTime.Now;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_Realistic_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;
            internDetails.DateOfBirth = new System.DateTime(1997,04,26);
            internDetails.UntilDate = System.DateTime.Now;
            internDetails.FromDate = new System.DateTime(2016,04,27);

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_Realistic_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;
            internDetails.DateOfBirth = System.DateTime.Now;
            internDetails.UntilDate = System.DateTime.Now;
            internDetails.FromDate = System.DateTime.Now;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }


        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagError_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("<Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagError_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagButClosedError_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<<Er/Sie>>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("<Er> ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagButClosedError_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<<Er/Sie>>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.replaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("<Sie> ist eine gute Softwareentwicklerin", ergebnis);
        }

        
        //getFirstOccuringGenderWord

        [TestMethod]
        public void TestGetFirstOccuringGenderWord()
        {
            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";

            string ergebnis = StringEditor.getFirstOccuringGenderWord(doctText);
            Assert.AreEqual("<<Er/Sie>>", ergebnis);
        }
    }
}
