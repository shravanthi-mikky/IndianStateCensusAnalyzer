using IndianStateCensus_Analyser;
using IndianStateCensus_Analyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensus_Analyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        string csvPath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCensusData.csv";
        //wrong path
        string IndianStateCensusDataWrongFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndianStateCensusData.csv";
        string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\CensusAnalyserTest\IndiaCensusTextFile.txt";
        string DelimiterIndianStateCensusDataFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\DelimiterIndiaStateCensusData.csv";

        string IndiaStateCodeCsvFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCode.csv";
        string IndianStateCodeDataWrongFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndianStateCode.csv";
        string DelimeterIndiaStateCode = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\DelimeterIndiaStateCode.csv";

        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";

        string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string IndiaStateCodeHeaders2 = "srNo,state name,tin,stateCode";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongExtensionFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
        //for UC2
        [Test]
        public void GivenIndiaStateCodeFile_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        //UC 2.2
        [Test]
        public void GivenIndiaStateCodeFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        //UC 2.4
        [Test]
        public void GivenIndiaStateCode_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                stateRecord = a1.LoadCensusData(DelimeterIndiaStateCode, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        //UC 2.5
        [Test]
        public void GivenIndiaStateCode_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}