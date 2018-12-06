using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DM
{
    class SimplifierOperations
    {
        public List<char> Glue(List<char> left, List<char> right)
        {
            List<char> answer = new List<char>();

            //if (left.Count == right.Count) {
            int diffIndex = -1;
            for (int i = 0; i < left.Count; i++) {
                if (left[i] != right[i]) {
                    if (diffIndex == -1) {
                        diffIndex = i;
                    } else {
                        diffIndex = -2;
                        break;
                    }
                }
            }
            if (diffIndex > -1) {
                for (int i = 0; i < left.Count; i++) {
                    if (i != diffIndex) {
                        answer.Add(left[i]);
                    } else {
                        answer.Add('$');
                    }
                }
            }
            //}

            return answer;
        }

        public List<char> SemiGlue(List<char> left, List<char> right)
        {
            List<char> answer = new List<char>();



            return answer;
        }

        public List<char> GeneralGlue(List<char> left, List<char> right)
        {
            List<char> answer = new List<char>();

            bool valid = false;

            for (int i = 0; i < left.Count; i++) {
                if (
                    (left[i] == '1' && right[i] == '0') ||
                    (left[i] == '0' && right[i] == '1')
                    ) {
                    valid = true;
                    break;
                }
            }

            if (valid) {
                for (int i = 0; i < left.Count; i++) {
                    if (left[i] != '$' && right[i] != '$' && left[i] != right[i]) {
                        answer.Add('$');
                    } else if (left[i] == right[i]) {
                        answer.Add(left[i]);
                    } else if (left[i] == '$') {
                        answer.Add(right[i]);
                    } else if (right[i] == '$') {
                        answer.Add(left[i]);
                    }
                }
            }
            return answer;
        }

        public List<char> Absorbtion(List<char> left, List<char> right)
        {
            List<char> answer = new List<char>();

            for (int i = 0; i < left.Count; i++) {
                if (
                    (left[i] != '$' && right[i] != '$' && left[i] != right[i]) ||
                    (left[i] != '$' && right[i] == '$')
                    ) {
                    return answer;
                }
            }
            return left;
        }
    }
}
