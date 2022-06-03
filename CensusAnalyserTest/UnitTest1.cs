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
        
        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
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
    }
}