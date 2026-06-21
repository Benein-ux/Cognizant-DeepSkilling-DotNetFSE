using System;
using System.Collections.Generic;

namespace DSA.Search
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        // Required for sorting before Binary Search
        public int CompareTo(Product other)
        {
            return this.ProductId.CompareTo(other.ProductId);
        }

        public override string ToString() => $"[ID: {ProductId}] {ProductName} ({Category})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product { ProductId = 105, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 101, ProductName = "Mouse", Category = "Electronics" },
                new Product { ProductId = 109, ProductName = "Keyboard", Category = "Electronics" },
                new Product { ProductId = 102, ProductName = "Monitor", Category = "Electronics" }
            };

            Console.WriteLine("--- Linear Search ---");
            var foundLinear = LinearSearch(products, 109);
            Console.WriteLine(foundLinear != null ? $"Found: {foundLinear}" : "Product not found.");

            Console.WriteLine("\n--- Binary Search ---");
            // Binary search STRICTLY requires a sorted array
            Array.Sort(products); 
            var foundBinary = BinarySearch(products, 102);
            Console.WriteLine(foundBinary != null ? $"Found: {foundBinary}" : "Product not found.");
            
            /* * ANALYSIS:
             * Binary search (O(log n)) is vastly superior for an e-commerce platform compared 
             * to Linear search (O(n)). E-commerce platforms are read-heavy (many searches). 
             * Keeping the data sorted allows binary search to instantly query millions of 
             * products in fractions of a second.
             */
        }

        public static Product LinearSearch(Product[] arr, int targetId)
        {
            foreach (var product in arr)
            {
                if (product.ProductId == targetId) return product;
            }
            return null;
        }

        public static Product BinarySearch(Product[] arr, int targetId)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid].ProductId == targetId)
                    return arr[mid];
                
                if (arr[mid].ProductId < targetId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }
    }
}