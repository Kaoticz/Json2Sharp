namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class KeywordTypes
{
    public const string Input = """
        {
            "class": "value",
            "for": "value",
            "1_number": "value"
        }
        """;

    public const string Output = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class KeywordTypes {
            @JsonProperty("class")
            private String classValue;

            @JsonProperty("for")
            private String forValue;

            @JsonProperty("1_number")
            private String _1Number;

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
            }

            public String get_1Number() {
                return _1Number;
            }

            public void set_1Number(String _1Number) {
                this._1Number = _1Number;
            }
        }
        """;

    public const string RecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record KeywordTypes(
            @JsonProperty("class") String classValue,
            @JsonProperty("for") String forValue,
            @JsonProperty("1_number") String _1Number
        ) {}
        """;
}