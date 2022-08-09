using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "course start")
                {
                    break;
                }

                List<string> parts = line
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string command = parts[0];
                string lessonTitle = parts[1];
                string exercise = lessonTitle + "-Exercise";

                if (command == "Add")
                {
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Add(lessonTitle);
                    }
                }

                else if (command == "Insert")
                {
                    int index = int.Parse(parts[2]);

                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Insert(index, lessonTitle);
                    }
                }

                else if (command == "Remove")
                {
                    if (lessons.Contains(lessonTitle))
                    {
                        lessons.Remove(lessonTitle);

                        if (lessons.Contains(exercise))
                        {
                            lessons.Remove(exercise);
                        }
                    }
                }

                else if (command == "Swap")
                {
                    string lessonToSwap = parts[2];

                    if (lessons.Contains(lessonTitle) && lessons.Contains(lessonToSwap))
                    {
                        int index1 = lessons.IndexOf(lessonTitle);
                        int index2 = lessons.IndexOf(lessonToSwap);

                        lessons[index1] = lessonToSwap;
                        lessons[index2] = lessonTitle;

                        if (lessons.Contains(exercise))
                        {
                            lessons.Insert(index2 + 1, exercise);
                            lessons.RemoveAt(index1 + 2);
                        }
                        else if (lessons.Contains(lessonToSwap + "-Exercise"))
                        {
                            lessons.Insert(index1 + 1, lessonToSwap + "-Exercise");
                            lessons.RemoveAt(index2 + 2);
                        }
                    }
                }

                else if (command == "Exercise")
                {
                    if (!lessons.Contains(exercise))
                    {
                        if (lessons.Contains(lessonTitle))
                        {
                            int index = lessons.IndexOf(lessonTitle);
                            lessons.Insert(index + 1, exercise);
                        }

                        else
                        {
                            lessons.Add(lessonTitle);
                            lessons.Add(exercise);
                        }
                    }
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i].TrimStart()}");
            }
        }
    }
}
