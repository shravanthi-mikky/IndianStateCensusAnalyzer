﻿// See https://aka.ms/new-console-template for more information
using CsvHelper;
using CsvHelper.Configuration;
using IndianStateCensus_Analyser;
using IndianStateCensus_Analyser.POCO;
using System.Globalization;
using static IndianStateCensus_Analyser.CensusAnalyser;

Console.WriteLine("Hello, Welcome to Indian State Census Analyser!");
CensusAnalyser censusAnalyser = new();
string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\CensusAnalyserTest\IndiaCensusTextFile.txt";
string IndianStateCensusDataWrongFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndianStateCensusData.csv";
string DelimiterIndianStateCensusDataFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\DelimiterIndiaStateCensusData.csv";

string csvPath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCensusData.csv";
string IndiaStateCodeCsvFilePath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCode.csv";
//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";
string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

while (true)
{
    Console.WriteLine("Please choose the option: \n1)UC1 - Check the number of records in CSV file\n2)UC1.2 - Given wrong file Path\n3)UC1.3 - Giving wrong text file as Input\n4)UC1.4-Throw exception if Delimeter is Wrong\n5)UC1.5-Throw exception if Wrong Headers are given\n6)UC2 Load India State code (Count Rows)");
    int option = Convert.ToInt32(Console.ReadLine());   
    switch(option)
    {
        case 1:
            Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Console.WriteLine(totalRecord.Count);
            break;
        case 2:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 3:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongExtensionFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 4:
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 5:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 6:
            Dictionary<string, CensusDTO> stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Console.WriteLine(stateRecord.Count);
            break;
        default :
            Console.WriteLine("Please choose Valid option!");
            break;

    }
}
