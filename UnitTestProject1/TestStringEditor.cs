using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string word = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);
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
            string word = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);
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
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er hat gute Arbeit geleistet", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_OneGenderWordInSentence_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<Er/Sie>> hat gute Arbeit geleistet";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie hat gute Arbeit geleistet",ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_MultipleGenderWordsInSentence_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

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
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

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
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

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
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

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
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }


        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagError_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("<Er ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagError_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;

            string doctText = "<<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("Sie ist eine gute Softwareentwicklerin", ergebnis);
        }

        [TestMethod]
        public void TestReplaceGenderWords_ThreeOpenTagButClosedError_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;

            string doctText = "<<<Er/Sie>>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";
            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);

            Assert.AreEqual("<Er> ist ein guter Softwareentwickler", ergebnis);
        }

        [TestMethod]
        public void TestGetFirstOccuringGenderWord()
        {
            string doctText = "<<Er/Sie>> ist <<ein/eine>> <<guter/gute>> <<Softwareentwickler/Softwareentwicklerin>>";

            string ergebnis = StringEditor.GetNextGenderWord(doctText);
            Assert.AreEqual("<<Er/Sie>>", ergebnis);
        }

        [TestMethod]
        public void TestGetFirstOccuringGenderWord_NONE()
        {
            string doctText = "Er ist ein guter Softwareentwickler";

            string ergebnis = StringEditor.GetNextGenderWord(doctText);
            Assert.AreEqual("", ergebnis);
        }

        [TestMethod]
        public void TestLastName_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;
            internDetails.LastName = "Schmidt";
            string doctText = "<<Herr/Frau>> <<Nachname>> hat die <<ihm/ihr>> übertragenen Aufgaben stets zu unserer vollsten Zufriedenheit erledigt.";

            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails,doctText);
            ergebnis = StringEditor.ReplaceDatesAndNames(internDetails, ergebnis);

            Assert.AreEqual("Herr Schmidt hat die ihm übertragenen Aufgaben stets zu unserer vollsten Zufriedenheit erledigt.", ergebnis);
        }

        [TestMethod]
        public void TestLastName_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;
            internDetails.LastName = "Schmidt";
            string doctText = "<<Herr/Frau>> <<Nachname>> hat die <<ihm/ihr>> übertragenen Aufgaben stets zu unserer vollsten Zufriedenheit erledigt.";

            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);
            ergebnis = StringEditor.ReplaceDatesAndNames(internDetails, ergebnis);

            Assert.AreEqual("Frau Schmidt hat die ihr übertragenen Aufgaben stets zu unserer vollsten Zufriedenheit erledigt.", ergebnis);
        }

        [TestMethod]
        public void TestReplaceDates_REALISTIC_MALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Male;
            internDetails.DateOfBirth = new System.DateTime(1997, 04, 26);
            internDetails.UntilDate = new System.DateTime(2016,06,28);
            internDetails.FromDate = new System.DateTime(2016, 04, 27);
            internDetails.FirstName = "Hans";
            internDetails.LastName = "Franz";

            string doctText = "<<Herr/Frau>> <<Vorname>> <<Nachname>>, geboren am <<Geburtsdatum>> war vom <<Anfangsdatum>> bis zum <<Enddatum>> als <<Praktikant/Praktikantin>> für uns tätig.";

            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);
            ergebnis = StringEditor.ReplaceDatesAndNames(internDetails, ergebnis);

            Assert.AreEqual("Herr Hans Franz, geboren am 26.04.1997 war vom 27.04.2016 bis zum 28.06.2016 als Praktikant für uns tätig.", ergebnis);
        }

        [TestMethod]
        public void TestReplaceDates_REALISTIC_FEMALE()
        {
            InternDetails internDetails = new InternDetails();
            internDetails.Sex = Sex.Female;
            internDetails.DateOfBirth = new System.DateTime(1997, 04, 26);
            internDetails.UntilDate = new System.DateTime(2016, 06, 28);
            internDetails.FromDate = new System.DateTime(2016, 04, 27);
            internDetails.FirstName = "Hans";
            internDetails.LastName = "Franz";

            string doctText = "<<Herr/Frau>> <<Vorname>> <<Nachname>>, geboren am <<Geburtsdatum>> war vom <<Anfangsdatum>> bis zum <<Enddatum>> als <<Praktikant/Praktikantin>> für uns tätig.";

            string ergebnis = StringEditor.ReplaceWordsBasedOnGender(internDetails, doctText);
            ergebnis = StringEditor.ReplaceDatesAndNames(internDetails, ergebnis);

            Assert.AreEqual("Frau Hans Franz, geboren am 26.04.1997 war vom 27.04.2016 bis zum 28.06.2016 als Praktikantin für uns tätig.", ergebnis);
        }
    }
}
