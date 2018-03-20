using Preps.Facebook;
using Preps.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Preps
{
    class Program
    {
        static TopCoder coder = new TopCoder();
        static MergeSort msort = new MergeSort();
        static QuickSort qsort = new QuickSort();
        static BucketSort binsort = new BucketSort();
        static Misc misc = new Misc();
        static Semaphore threadPool = new Semaphore(3, 5);
        static void DoTask(int threadId)
        {
            threadPool.WaitOne();

            Console.WriteLine("Thread {0} is inside the critical section...", threadId);

            Thread.Sleep(10000);

            threadPool.Release();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FromCareerCup.IsOrdered(new[] { "cc", "cb", "bb", "ac" }, "abc".ToCharArray()));
            Console.WriteLine(FromCareerCup.IsOrdered(new[] { "cc", "cb", "bb", "ac" }, "cba".ToCharArray()));
            Console.WriteLine(FromCareerCup.IsOrdered(new[] { "cc", "cb", "bb", "ac" }, "bca".ToCharArray()));
            Console.WriteLine(FromCareerCup.IsOrdered(new[] { "cc", "cb", "bb", "ac", "cat", "aab" }, "cba".ToCharArray()));
            //var mAvg = new FromCareerCup.MovingAvg(3);
            //foreach (var num in Enumerable.Range(1, 10))
            //{
            //    Console.WriteLine("New Num: {0}. Ang: {1}", num, mAvg.GetMovingAverage(num));
            //}

            //Console.WriteLine("OneEditApart('cat', 'cat') = {0}", Prepping.OneEditApart("cat", "cat"));
            //Console.WriteLine("OneEditApart('cat', 'dog') = {0}", Prepping.OneEditApart("cat", "dog"));
            //Console.WriteLine("OneEditApart('cat', 'cats') = {0}", Prepping.OneEditApart("cat", "cats"));
            //Console.WriteLine("OneEditApart('cat', 'cut') = {0}", Prepping.OneEditApart("cat", "cut"));
            //Console.WriteLine("OneEditApart('cat', 'cast') = {0}", Prepping.OneEditApart("cat", "cast"));
            //Console.WriteLine("OneEditApart('cat', 'at') = {0}", Prepping.OneEditApart("cat", "at"));
            //Console.WriteLine("OneEditApart('cat', 'act') = {0}", Prepping.OneEditApart("cat", "act"));


            //Prepping.print_look_and_say_seq(10);

            //var arr = Prepping.Spiral(8);
            //var sb = new StringBuilder();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0; j < arr[i].Length; j++)
            //    {
            //        sb.AppendFormat("{0}\t", arr[i][j]);
            //    }
            //    sb.AppendLine();
            //}
            //Console.WriteLine(sb);

            //var people = new []
            //{
            //    //new Prepping.Person { Birth = 2000, Death = 2001 },
            //    //new Prepping.Person { Birth = 2001, Death = 2002 },
            //    new Prepping.Person { Birth = 2011, Death = 2018 },
            //    new Prepping.Person { Birth = 2000, Death = 2010 },
            //    new Prepping.Person { Birth = 1999, Death = 2018 },
            //    new Prepping.Person { Birth = 1970, Death = 1999 },
            //    new Prepping.Person { Birth = 2002, Death = 2006 },
            //    new Prepping.Person { Birth = 1970, Death = 2005 },
            //    new Prepping.Person { Birth = 1983, Death = 2010 },
            //    new Prepping.Person { Birth = 1971, Death = 2005 },
            //};

            //int ans = Prepping.GetYearWithMostAlive_Solution2(people);
            //Console.WriteLine("Year with most alive: {0}", ans);


            //Combinatrionics.PrintWords("497");//1927
            //var subsets = Combinatrionics.GetSubsets_BitArray(new List<string> { "app", "bed", "car", "dop" });
            //foreach (var subset in subsets)
            //{
            //    Console.Write("{ ");
            //    Console.Write("{0} ", string.Join(" ", subset));
            //    Console.WriteLine("}");
            //}
            //var combis = Combinatrionics.Combinations("abcd");
            //foreach (var subset in combis)
            //{
            //    Console.Write("{ ");
            //    Console.Write("{0} ", subset);
            //    Console.WriteLine("}");
            //}
            //new Qns().PrintAllCombinations(new[]
            //{
            //    new[] {1,2,3},
            //    new[] {4,5},
            //    //new[] {6,7,8},
            //    //new[] {9},
            //});
            //Console.WriteLine(new Qns().GetNearest(new[] { 1, 3, 5 }, 4));
            //new ProducerConsumer().Run(10);
            //new DiningPhilosophers().StartEating();
            //for (int i = 0; i < 10; i++)
            //{
            //    int j = i;
            //   Task.Factory.StartNew(() => DoTask(j));
            //}
            ////var ans = coder.canObtain("BBBBABABBBBBBA", "BBBBABABBABBBBBBABABBBBBBBBABAABBBAA");
            //var ans = misc.combination(5,3);
            //Console.WriteLine(ans);
            //var arr = new[] { 12, 11, 13, 5, 6, 7 };
            //qsort.Sort(arr);
            //var kthSmallest = misc.kthLargestElement(arr, 4);
            //Console.WriteLine("kthSmallest: {0}", kthSmallest);
            //Console.WriteLine("Sorted: {0}", arr.PrintList());
            //var linkedList = new LinkedListNode<int>(12)
            //{
            //    Next = new LinkedListNode<int>(11)
            //    {
            //        Next = new LinkedListNode<int>(13)
            //        {
            //            Next = new LinkedListNode<int>(5)
            //            {
            //                Next = new LinkedListNode<int>(6)
            //                {
            //                    Next = new LinkedListNode<int>(7)
            //                    {
            //                        Next = null
            //                    }
            //                }
            //            }
            //        }
            //    }
            //};
            //Console.WriteLine("List: {0}", linkedList.PrintList());
            //linkedList = sort.Sort(linkedList);
            //Console.WriteLine("Sorted: {0}", linkedList.PrintList());

            Console.ReadKey();
        }

    }
}
