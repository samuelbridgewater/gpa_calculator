using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace gpa_calculator
{
    class CalcLogic
    {
        static void CalculateGpa(int creditPoints, int[] grades)
        {
            List<double> semesterAverage = new List<double>();
            double finalGpa = 0;

            foreach (int grade in grades)
            {
                finalGpa += grade * creditPoints;

                if (grade % 4 == 0)
                {
                    semesterAverage.Add(grade);
                }
            }
            creditPoints = (grades.Length * creditPoints);
            finalGpa = finalGpa / creditPoints;

            Console.WriteLine("Your overall GPA is: {0}", finalGpa);
        }

        static void CalculateSemesterGPA(int[] grades, int unitsPerSem, int creditPoints)
        {    
            if (grades.Length % unitsPerSem != 0)
            {
                Console.WriteLine("Are you sure you entered all possible grades?");
                return;
            }
            
            double[] semAverage = new double[grades.Length / unitsPerSem];
            int semCount = 0;
            int ctr = 0;
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            for (int i = 0; i <= grades.Length; i++)
            {
                if (i % unitsPerSem == 0 && i > 0)
                {
                    semAverage[semCount] = semAverage[semCount] / (creditPoints * unitsPerSem);
                  
                    Console.Write("| Semester {0} GPA:{1} ", semCount + 1, semAverage[semCount]);
                    
                    if (semAverage[semCount] >= 6.5)
                    {
                        Console.WriteLine("\tAdmitted to Deans List of Students with Excellent Academic Performance |");
                    }
                    else
                    {
                        Console.Write("\t\t\t\t\t\t\t\t\t       |");
                        Console.WriteLine();
                    }


                    if (ctr == grades.Length)
                    {
                        Console.WriteLine("------------------------------------------------------------------------------------------------");
                        return;
                    }
                    semCount += 1;
                }
                semAverage[semCount] += grades[ctr] * creditPoints;
                ctr++;                   
            }
            return;
        }


        static void Main(string[] args)
        {
            Console.Write("How many units per semester? ");
            int unitsPerSem = Convert.ToInt32(Console.ReadLine());
            Console.Write("How many units have been graded? ");
            int totalUnits = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[totalUnits];
            Console.Write("How many credit points per unit? ");
            int creditPoints = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < totalUnits; i++)
            {
                Console.Write("Enter grade for unit {0}: ", i + 1);
                grades[i] = Convert.ToInt32(Console.ReadLine());
            }
           
            CalculateSemesterGPA(grades, unitsPerSem, creditPoints);
            CalculateGpa(creditPoints, grades);
        }
    }
}
