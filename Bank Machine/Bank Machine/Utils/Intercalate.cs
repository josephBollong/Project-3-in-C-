using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils {
    class Intercalate {
        public static String intercalate(String y, String...x) {
            return intercalate(x, y);
        }

        public static String intercalate(String[] x, String y) {
            return intercalate(Arrays.asList(x), y);
        }

        public static String intercalate(Iterable<String> x, String y) {
            Iterator<String> _itr = x.iterator();
            StringBuilder _result = new StringBuilder();
            while (_itr.hasNext()) {
                _result.append(_itr.next());
                if (_itr.hasNext()) {
                    _result.append(y);
                }
            }
            return _result.toString();
        }
    }
}
