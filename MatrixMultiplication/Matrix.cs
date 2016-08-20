using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    public class Matrix
    {
        private List<List<int>> matrix;

        public Matrix()
        {
            matrix = new List<List<int>>();
        }
        public Matrix(List<List<int>> matrix)
        {
            this.matrix = matrix;
        }
        public static Matrix operator * (Matrix a, Matrix b)
        {
            List<List<int>> aMatrix = a.getMatrix();
            List<List<int>> bMatrix = b.getMatrix();
            List<List<int>> resultMatrix = new List<List<int>>();
            for (int row = 0; row < aMatrix.Count; row++)
            { 
                List<int> tempMatrix = new List<int>();
                for (int col = 0; col < bMatrix[0].Count; col++)
                {
                    int tempInt = 0;
                    for (int inner = 0; inner < aMatrix[0].Count; inner++)
                    {
                        tempInt += (aMatrix[row][inner] * bMatrix[inner][col]);
                    }
                    tempMatrix.Add(tempInt);
                }
                    resultMatrix.Add(tempMatrix);
            }
            return new Matrix(resultMatrix);
        }
        public void scalarMultiply(int scalar){
            for(int row = 0;row<this.matrix.Count;row++){
                for(int col = 0;col<this.matrix[0].Count;col++){
                    this.matrix[row][col] *= scalar;
                }
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            List<List<int>> aMatrix = a.getMatrix();
            List<List<int>> bMatrix = b.getMatrix();
            List<List<int>> resultMatrix = new List<List<int>>();
            for (int row = 0; row < aMatrix.Count; row++)
            {
                List<int> tempMatrix = new List<int>();
                for (int col = 0; col < bMatrix[0].Count; col++)
                {

                    tempMatrix.Add(aMatrix[row][col] + bMatrix[row][col]);

                }
                resultMatrix.Add(tempMatrix);
            }
            return new Matrix(resultMatrix);
        }

        public List<List<int>> getMatrix() { return matrix; }
        public void setMatrix(List<List<int>> matrix) { this.matrix = matrix; }
        public int getRowCount() { 
            if(this.matrix != null)
                return this.matrix.Count;
            return 0;
        }
        public int getColCount() { 
            if(this.getRowCount() > 0 && this.matrix[0] != null)
                return this.matrix[0].Count;
            return 0;
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Matrix p = obj as Matrix;
            if ((System.Object)p == null)
            {
                return false;
            }
            if (this.getRowCount() != p.getRowCount()) return false;
            if (this.getColCount() != p.getColCount()) return false;
            if (this.matrix == null && p.getMatrix() == null) return true;
            if (this.matrix == null || p.getMatrix() == null) return false;
            for (int i = 0; i < this.matrix.Count; i++)
            {
                if (!listsAreEqual(this.matrix[i], p.getMatrix()[i]))
                    return false;
            }

            // Return true if the fields match:
            return true;
        }
        private bool listsAreEqual(List<int> a, List<int> b)
        {
            if (a == null && b == null) 
                return true;
            if (a == null || b == null)
                return false;
            if(a.Count == 0)
                return true;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        public override string ToString()
        {
            string result = "[";
            bool outerFirst = true;
            for (int col = 0; col < this.matrix[0].Count; col++)
            {
                if (!outerFirst) result += ",";
                outerFirst = false;
                result += "[";
                bool innerFirst = true;
                for (int row = 0; row < this.matrix.Count; row++)
                {
                    if (!innerFirst) result += ",";
                    innerFirst = false;
                    result += this.matrix[row][col];

                }
                result += "]";
            }

            return result+"]";
        }
    }
}
