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
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }
    
    [TestCase(new int[] {2, 0, 0}, 1, new int[] {1, 3}, 2)]
    [TestCase(new int[] {4, 0, 0, 0, 0}, 1, new int[] {1, 2, 3, 5}, 4)]
    [TestCase(new int[] {4,5,0,0,0,0}, 2, new int[] {1,2,3,6}, 4)]
    public void Merge_InsertFirstIntoSecond(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }

    [TestCase(new int[] {1, 2, 3, 5, 6, 0}, 5, new int[] {4}, 1)]
    [TestCase(new int[] {1, 2, 3, 6, 0, 0}, 4, new int[] {4, 5}, 2)]
    [TestCase(new int[] {1, 2, 4, 5, 6, 0,}, 5, new int[] {3}, 1)]
    [TestCase(new int[] {1, 2, 4, 5, 0,}, 4, new int[] {3}, 1)]
    [TestCase(new int[] {1, 2, 4, 0}, 3, new int[] {3}, 1)]
    public void Merge_InsertSecondIntoFirst(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }

    [TestCase(new int[] {1, 0}, 1, new int[] {2}, 1)]
    [TestCase(new int[] {1, 3, 0}, 2, new int[] {2}, 1)]
    [TestCase(new int[] {1, 3, 0, 0}, 2, new int[] {2, 4}, 2)]
    [TestCase(new int[] {1, 3, 5, 0, 0, 0}, 3, new int[] {2, 4, 6}, 3)]
    public void Merge_OneByOne(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }

    [TestCase(new int[] {0}, 0, new int[] {1}, 1)]
    [TestCase(new int[] {0, 0}, 0, new int[] {1, 2}, 2)]
    [TestCase(new int[] {1}, 1, new int[] {}, 0)]
    [TestCase(new int[] {1, 2}, 2, new int[] {}, 0)]
    public void Merge_OneEmpty(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }
    [TestCase(new int[] {-1,0,0,5,7,7,0,0,0,0}, 6, new int[] {-1, 2, 2, 4}, 4)]
    public void Merge_Shuffle(int[] nums1, int m, int[] nums2, int n)
    {
        List<int> expected = MergeAndSort(nums1, m, nums2, n);
        _mergeService.Merge(nums1, m, nums2, n);
        CollectionAssert.AreEqual(expected, nums1);
    }

    private List<int> MergeAndSort(int[] nums1, int length1, int[] nums2, int length2)
    {
        List<int> merged = new (length1 + length2);
        for (int i = 0; i < System.Math.Max(length1, length2); i++)
        {
            if(i < length1)
            {
                merged.Add(nums1[i]);
            }
            if (i < length2)
            {
                merged.Add(nums2[i]);
            }
        }
        merged.Sort();
        return merged;
    }
}
