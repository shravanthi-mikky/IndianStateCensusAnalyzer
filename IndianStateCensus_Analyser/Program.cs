// See https://aka.ms/new-console-template for more information
using CsvHelper;
using CsvHelper.Configuration;
using IndianStateCensus_Analyser;
using IndianStateCensus_Analyser.POCO;
using System.Globalization;
using static IndianStateCensus_Analyser.CensusAnalyser;

Console.WriteLine("Hello, Welcome to Indian State Census Analyser!");
CensusAnalyser censusAnalyser = new();
string csvPath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCensusData.csv";
//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
Console.WriteLine(totalRecord.Count);