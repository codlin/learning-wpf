using System.ComponentModel;

namespace BusinessLayerValidation;
internal class Person : IDataErrorInfo {
    public int Age { get; set; }

    public string this[string name] {
        get {
            string result = "";
            if (name == "Age") {
                if (Age < 0 || Age > 150) {
                    result = "年龄必须大于 0 小于150";
                }
            }
            return result;
        }
    }
    public string Error => "";
}
