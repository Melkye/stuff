using NUnit.Framework;
using Merge.Services;
using System.Collections.Generic;

namespace Merge.Services.Tests;

[TestFixture]
public class MergeService_Merge
{
    private MergeService _mergeService;
    [SetUp]
    public void SetUp()
    {
        _mergeService = new MergeService();
    }

    [TestCase(new int[] {1, 2, 3, 0, 0, 0}, 3, new int[] {4, 5, 6}, 3)]
    [TestCase(new int[] {1, 2, 3}, 3, new int[] {}, 0)]
    [TestCase(new int[] {1, 2, 0}, 2, new int[] {3}, 1)]
    public void Merge_FirstLessNumsThanSecond(int[] nums1, int m, int[] nums2, int n)
    {
        int[] expected = new int[n+m];
        for (int i = 0; i < System.Math.Max(n, m); i++)
        {
            if(i < m)
            {
                expected[i] = nums1[i];
            }
            if (i < n)
            {
                expected[i+m] = nums2[i];
            }
        }
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }
    
    [TestCase(new int[] {4,0,0,0,0,0}, 1, new int[] {1,2,3,5,6}, 5)]
    public void Merge_InsertFirstIntoSecond(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = new List<int>(n+m);
        for (int i = 0; i < System.Math.Max(n, m); i++)
        {
            if(i < m)
            {
                expected.Add(nums1[i]);
            }
            if (i < n)
            {
                expected.Add(nums2[i]);
            }
        }
        expected.Sort();
        foreach (int item in expected)
        {
            System.Console.WriteLine(item + " ");
        }
        System.Console.WriteLine("\n");
        
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }
}