﻿using CsvHelper;
using CsvHelper.Configuration;
using IndianStateCensus_Analyser.POCO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensus_Analyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
        // my own method
        //read from csv file
        public void ReadCsvFile()
        {
            string csvPath = @"C:\Users\Admin\Desktop\CSharp\IndianStateCensusAnalyzer\IndianStateCensus_Analyser\IndiaStateCensusData.csv";
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };
            int count = 0;
            using var streamReader = File.OpenText(csvPath);
            using var csvReader = new CsvReader(streamReader, csvConfig);
            string value;
            int row = 0;
            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    count++;
                    //Console.Write($"{value} ");
                }
                //Console.WriteLine();
                row++;
            }
            Console.WriteLine(row);
        }
    }
}
