namespace Merge.Services;
public class MergeService
{
    //public void Merge(int[] nums1, int m, int[] nums2, int n)
    //{
    //    int i = 0;
    //    int j = 0;
    //    int movedEnd = m - 1;
    //    int movedAndNotCompared = m - 1;

    //    while (i < m + n)
    //    {
    //        if (i >= m && (i > movedAndNotCompared)) // movedAndNotCompared == m - 1 ?
    //        {
    //            nums1[i] = nums2[j];
    //            i++;
    //            j++;
    //        }
    //        else
    //        {
    //            if (i < movedAndNotCompared && movedAndNotCompared != m - 1)
    //            //if (movedEnd != int.MinValue)
    //            {
    //                if (j < n)
    //                {
    //                    switch (GetMin(nums1[i], nums2[j], nums1[movedAndNotCompared]))
    //                    {
    //                        case int num1 when num1 == nums1[i]:
    //                            i++;
    //                            break;
    //                        case int num2 when num2 == nums2[j]:
    //                            if (GetMin(nums1[i], nums1[movedAndNotCompared]) == nums1[i]) //
    //                            {
    //                                int tempo = nums1[i];
    //                                nums1[i] = nums1[movedAndNotCompared];
    //                                nums1[movedAndNotCompared] = tempo;
    //                            }
    //                            movedEnd++;
    //                            nums1[movedEnd] = nums1[i];
    //                            nums1[i] = nums2[j];
    //                            j++;
    //                            i++;
    //                            break;
    //                        case int moved when moved == nums1[movedAndNotCompared]:
    //                            int temp = nums1[i];
    //                            nums1[i] = nums1[movedAndNotCompared];
    //                            nums1[movedAndNotCompared] = temp;
    //                            i++;
    //                            break;
    //                    }
    //                }
    //                else
    //                {
    //                    if (GetMin(nums1[i], nums1[movedAndNotCompared]) == nums1[movedAndNotCompared])
    //                    {
    //                        int temp = nums1[i];
    //                        nums1[i] = nums1[movedAndNotCompared];
    //                        nums1[movedAndNotCompared] = temp;
    //                    }
    //                    i++;
    //                }
    //                if (movedAndNotCompared == i && movedAndNotCompared < movedEnd)
    //                {
    //                    movedAndNotCompared++;
    //                }
    //            }
    //            else
    //            {
    //                if (j < n && GetMin(nums1[i], nums2[j]) == nums2[j])
    //                {
    //                    movedEnd++;
    //                    movedAndNotCompared++;
    //                    nums1[movedEnd] = nums1[i];
    //                    nums1[i] = nums2[j];
    //                    j++;
    //                }
    //                i++;
    //            }
    //        }
    //    }

    //}
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0;
        int j = 0;
        int movedEnd = m - 1;
        int shift = -1;
        //int movedAndNotCompared = m - 1;

        while (i < m + n)
        {
            if (i >= m && (i > movedEnd)) // movedAndNotCompared == m - 1 ?
            {
                nums1[i] = nums2[j];
                i++;
                j++;
            }
            else
            {
                if (i < movedEnd && movedEnd != m - 1)
                {
                    if (j < n)
                    {
                        switch (GetMin(nums1[i], nums2[j], nums1[movedEnd - shift]))
                        {
                            case int num1 when num1 == nums1[i]:
                                i++;
                                break;
                            case int num2 when num2 == nums2[j]:
                                if (GetMin(nums1[i], nums1[movedEnd - shift]) == nums1[i])
                                {
                                    int tempo = nums1[i];
                                    nums1[i] = nums1[movedEnd - shift];
                                    nums1[movedEnd - shift] = tempo;
                                }
                                movedEnd++;
                                shift++;
                                nums1[movedEnd] = nums1[i];
                                nums1[i] = nums2[j];
                                j++;
                                i++;
                                break;
                            case int moved when moved == nums1[movedEnd - shift]:
                                int temp = nums1[i];
                                nums1[i] = nums1[movedEnd - shift];
                                nums1[movedEnd - shift] = temp;
                                i++;
                                break;
                        }
                    }
                    else
                    {
                        if (GetMin(nums1[i], nums1[movedEnd - shift]) == nums1[i])
                        {
                            i++;
                        }
                        else
                        {
                            int temp = nums1[i];
                            nums1[i] = nums1[movedEnd - shift];
                            nums1[movedEnd - shift] = temp;
                            i++;
                        }
                    }
                    if (i == movedEnd - shift)
                    {
                        shift--;
                    }
                }
                else
                {
                    if (j < n && GetMin(nums1[i], nums2[j]) == nums1[i] || j >= n)
                    {
                        i++;
                    }
                    else if (j < n)
                    {
                        movedEnd++;
                        shift++;
                        nums1[movedEnd] = nums1[i];
                        nums1[i] = nums2[j];
                        j++;
                        i++;
                    }
                }
            }
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
