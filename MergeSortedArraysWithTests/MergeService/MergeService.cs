namespace Merge.Services;
public class MergeService
{
    public  void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0;
        int j = 0;
        int k = m - 1;
        int p = k;
        // int temp = int.MinValue;
        while (i < m + n)
        {
            if (p == i && p < k)
                p++;
            //temp = nums1[i];
            if (j < n)
            {
                if (k > m - 1 || i >= m ) // else
                {
                    if (i > k)
                    {
                        nums1[i] = nums2[j];
                        j++;
                    }
                    else
                    {
                        switch (GetMin(nums1[i], nums2[j], nums1[p])) // check border cases
                        {
                            // case nums1[i]: increment i
                            case int num when num == nums2[j]:
                                k++;
                                nums1[k] = nums1[i];
                                nums1[i] = nums2[j];
                                j++;
                                break;
                            case int num when num == nums1[p]:
                                if (i <= p)
                                {
                                    int temp = nums1[i];
                                    nums1[i] = nums1[p];
                                    nums1[p] = temp;
                                }
                                break;
                        }
                    }
                }
                else
                {
                    if (GetMin(nums1[i], nums2[j]) == nums2[j])
                    {
                        k++;
                        nums1[k] = nums1[i];
                        nums1[i] = nums2[j];
                        j++;
                    }
                }
            }
            else
            {
                if (GetMin(nums1[i], nums1[p]) == nums1[p])
                {
                    //if (i < p)
                    //{
                        int temp = nums1[i];
                        nums1[i] = nums1[p];
                        nums1[p] = temp;
                    //}
                }
            }
            i++;
        }
    }

    private int GetMin(int a, int b, int c)
    {
        if (a < b)
        {
            return GetMin(a, c);
        }
        else
        {
            return GetMin(b, c);
        }
    }
    private int GetMin(int a, int b)
    {
        if (a < b)
        {
            return a;
        }
        return b;
    }
}
