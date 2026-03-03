namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class ArrayTypes
{
    public const string Input = """
        {
            "empty_array": [],
            "int_array": [ 1, 2, 3 ],
            "nullable_int_array" : [ 1, 2, null ],
            "float_array": [ 1.0, 2.0, 3.0 ],
            "nullable_float_array" : [ 1.0, 2.0, null ],
            "string_array": [ "a", "b", "c" ],
            "nullable_string_array": [ "a", "b", null ],
            "mixed_array": [ 1, "a", 2.1 ],
            "nullable_mixed_array": [ 1, "a", 2.1, null ],
            "thing_array": [ { "text": "hello" } ],
            "nullable_thing_array": [ { "text": "hello" }, null ],
            "null_array": [ null ],
            "objects_array": [
                { "text": "hello" },
                { "id": 1 }
            ],
            "nullable_objects_array": [
                { "text": "hello" },
                { "id": 1 },
                null
            ]
        }
        """;

    public const string NoAnnotationOutput = """
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            private List<Object> emptyArray = new ArrayList<>();

            private List<Integer> intArray = new ArrayList<>();

            private List<Integer> nullableIntArray = new ArrayList<>();

            private List<Float> floatArray = new ArrayList<>();

            private List<Float> nullableFloatArray = new ArrayList<>();

            private List<String> stringArray = new ArrayList<>();

            private List<String> nullableStringArray = new ArrayList<>();

            private List<Object> mixedArray = new ArrayList<>();

            private List<Object> nullableMixedArray = new ArrayList<>();

            private List<ThingArray> thingArray = new ArrayList<>();

            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            private List<Object> nullArray = new ArrayList<>();

            private List<Object> objectsArray = new ArrayList<>();

            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @JsonProperty("empty_array")
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @JsonProperty("empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.ArrayList;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.ArrayList;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.ArrayList;
        import java.util.List;
        import lombok.NonNull;

        public class Root {
            @JsonProperty("empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.ArrayList;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("empty_array")
            @Nonnull
            private List<Object> emptyArray = new ArrayList<>();

            @JsonProperty("int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();

            @JsonProperty("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @JsonProperty("float_array")
            @Nonnull
            private List<Float> floatArray = new ArrayList<>();

            @JsonProperty("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @JsonProperty("string_array")
            @Nonnull
            private List<String> stringArray = new ArrayList<>();

            @JsonProperty("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @JsonProperty("mixed_array")
            @Nonnull
            private List<Object> mixedArray = new ArrayList<>();

            @JsonProperty("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @JsonProperty("thing_array")
            @Nonnull
            private List<ThingArray> thingArray = new ArrayList<>();

            @JsonProperty("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @JsonProperty("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @JsonProperty("objects_array")
            @Nonnull
            private List<Object> objectsArray = new ArrayList<>();

            @JsonProperty("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @JsonProperty("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @JsonProperty("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @SerializedName("empty_array")
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @SerializedName("empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.ArrayList;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.ArrayList;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.ArrayList;
        import java.util.List;
        import lombok.NonNull;

        public class Root {
            @SerializedName("empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.ArrayList;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("empty_array")
            @Nonnull
            private List<Object> emptyArray = new ArrayList<>();

            @SerializedName("int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();

            @SerializedName("nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @SerializedName("float_array")
            @Nonnull
            private List<Float> floatArray = new ArrayList<>();

            @SerializedName("nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @SerializedName("string_array")
            @Nonnull
            private List<String> stringArray = new ArrayList<>();

            @SerializedName("nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @SerializedName("mixed_array")
            @Nonnull
            private List<Object> mixedArray = new ArrayList<>();

            @SerializedName("nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @SerializedName("thing_array")
            @Nonnull
            private List<ThingArray> thingArray = new ArrayList<>();

            @SerializedName("nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @SerializedName("null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @SerializedName("objects_array")
            @Nonnull
            private List<Object> objectsArray = new ArrayList<>();

            @SerializedName("nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @SerializedName("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @SerializedName("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @Json(name = "empty_array")
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.ArrayList;
        import java.util.List;

        public class Root {
            @Json(name = "empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import java.util.ArrayList;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import java.util.ArrayList;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "empty_array")
            @NotNull
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            @NotNull
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            @NotNull
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            @NotNull
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            @NotNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            @NotNull
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import java.util.ArrayList;
        import java.util.List;
        import lombok.NonNull;

        public class Root {
            @Json(name = "empty_array")
            @NonNull
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            @NonNull
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            @NonNull
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            @NonNull
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            @NonNull
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            @NonNull
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import java.util.ArrayList;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "empty_array")
            @Nonnull
            private List<Object> emptyArray = new ArrayList<>();

            @Json(name = "int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();

            @Json(name = "nullable_int_array")
            @Nullable
            private List<Integer> nullableIntArray = new ArrayList<>();

            @Json(name = "float_array")
            @Nonnull
            private List<Float> floatArray = new ArrayList<>();

            @Json(name = "nullable_float_array")
            @Nullable
            private List<Float> nullableFloatArray = new ArrayList<>();

            @Json(name = "string_array")
            @Nonnull
            private List<String> stringArray = new ArrayList<>();

            @Json(name = "nullable_string_array")
            @Nullable
            private List<String> nullableStringArray = new ArrayList<>();

            @Json(name = "mixed_array")
            @Nonnull
            private List<Object> mixedArray = new ArrayList<>();

            @Json(name = "nullable_mixed_array")
            @Nullable
            private List<Object> nullableMixedArray = new ArrayList<>();

            @Json(name = "thing_array")
            @Nonnull
            private List<ThingArray> thingArray = new ArrayList<>();

            @Json(name = "nullable_thing_array")
            @Nullable
            private List<NullableThingArray> nullableThingArray = new ArrayList<>();

            @Json(name = "null_array")
            @Nullable
            private List<Object> nullArray = new ArrayList<>();

            @Json(name = "objects_array")
            @Nonnull
            private List<Object> objectsArray = new ArrayList<>();

            @Json(name = "nullable_objects_array")
            @Nullable
            private List<Object> nullableObjectsArray = new ArrayList<>();

            public List<Object> getEmptyArray() {
                return emptyArray;
            }

            public void setEmptyArray(List<Object> emptyArray) {
                this.emptyArray = emptyArray;
            }

            public List<Integer> getIntArray() {
                return intArray;
            }

            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }

            public List<Integer> getNullableIntArray() {
                return nullableIntArray;
            }

            public void setNullableIntArray(List<Integer> nullableIntArray) {
                this.nullableIntArray = nullableIntArray;
            }

            public List<Float> getFloatArray() {
                return floatArray;
            }

            public void setFloatArray(List<Float> floatArray) {
                this.floatArray = floatArray;
            }

            public List<Float> getNullableFloatArray() {
                return nullableFloatArray;
            }

            public void setNullableFloatArray(List<Float> nullableFloatArray) {
                this.nullableFloatArray = nullableFloatArray;
            }

            public List<String> getStringArray() {
                return stringArray;
            }

            public void setStringArray(List<String> stringArray) {
                this.stringArray = stringArray;
            }

            public List<String> getNullableStringArray() {
                return nullableStringArray;
            }

            public void setNullableStringArray(List<String> nullableStringArray) {
                this.nullableStringArray = nullableStringArray;
            }

            public List<Object> getMixedArray() {
                return mixedArray;
            }

            public void setMixedArray(List<Object> mixedArray) {
                this.mixedArray = mixedArray;
            }

            public List<Object> getNullableMixedArray() {
                return nullableMixedArray;
            }

            public void setNullableMixedArray(List<Object> nullableMixedArray) {
                this.nullableMixedArray = nullableMixedArray;
            }

            public List<ThingArray> getThingArray() {
                return thingArray;
            }

            public void setThingArray(List<ThingArray> thingArray) {
                this.thingArray = thingArray;
            }

            public List<NullableThingArray> getNullableThingArray() {
                return nullableThingArray;
            }

            public void setNullableThingArray(List<NullableThingArray> nullableThingArray) {
                this.nullableThingArray = nullableThingArray;
            }

            public List<Object> getNullArray() {
                return nullArray;
            }

            public void setNullArray(List<Object> nullArray) {
                this.nullArray = nullArray;
            }

            public List<Object> getObjectsArray() {
                return objectsArray;
            }

            public void setObjectsArray(List<Object> objectsArray) {
                this.objectsArray = objectsArray;
            }

            public List<Object> getNullableObjectsArray() {
                return nullableObjectsArray;
            }

            public void setNullableObjectsArray(List<Object> nullableObjectsArray) {
                this.nullableObjectsArray = nullableObjectsArray;
            }
        }

        public class ThingArray {
            @Json(name = "text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NullableThingArray {
            @Json(name = "text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        import java.util.List;

        public record Root(
            List<Object> emptyArray,
            List<Integer> intArray,
            List<Integer> nullableIntArray,
            List<Float> floatArray,
            List<Float> nullableFloatArray,
            List<String> stringArray,
            List<String> nullableStringArray,
            List<Object> mixedArray,
            List<Object> nullableMixedArray,
            List<ThingArray> thingArray,
            List<NullableThingArray> nullableThingArray,
            List<Object> nullArray,
            List<Object> objectsArray,
            List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            String text
        ) {}

        public record NullableThingArray(
            String text
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.List;

        public record Root(
            @JsonProperty("empty_array") List<Object> emptyArray,
            @JsonProperty("int_array") List<Integer> intArray,
            @JsonProperty("nullable_int_array") List<Integer> nullableIntArray,
            @JsonProperty("float_array") List<Float> floatArray,
            @JsonProperty("nullable_float_array") List<Float> nullableFloatArray,
            @JsonProperty("string_array") List<String> stringArray,
            @JsonProperty("nullable_string_array") List<String> nullableStringArray,
            @JsonProperty("mixed_array") List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") List<Object> nullableMixedArray,
            @JsonProperty("thing_array") List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") List<Object> nullArray,
            @JsonProperty("objects_array") List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") String text
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.List;

        public record Root(
            @JsonProperty("empty_array") @NotNull List<Object> emptyArray,
            @JsonProperty("int_array") @NotNull List<Integer> intArray,
            @JsonProperty("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @JsonProperty("float_array") @NotNull List<Float> floatArray,
            @JsonProperty("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @JsonProperty("string_array") @NotNull List<String> stringArray,
            @JsonProperty("nullable_string_array") @Nullable List<String> nullableStringArray,
            @JsonProperty("mixed_array") @NotNull List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @JsonProperty("thing_array") @NotNull List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") @Nullable List<Object> nullArray,
            @JsonProperty("objects_array") @NotNull List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") @NotNull String text
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("empty_array") @NonNull List<Object> emptyArray,
            @JsonProperty("int_array") @NonNull List<Integer> intArray,
            @JsonProperty("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @JsonProperty("float_array") @NonNull List<Float> floatArray,
            @JsonProperty("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @JsonProperty("string_array") @NonNull List<String> stringArray,
            @JsonProperty("nullable_string_array") @Nullable List<String> nullableStringArray,
            @JsonProperty("mixed_array") @NonNull List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @JsonProperty("thing_array") @NonNull List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") @Nullable List<Object> nullArray,
            @JsonProperty("objects_array") @NonNull List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") @NonNull String text
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("empty_array") @NotNull List<Object> emptyArray,
            @JsonProperty("int_array") @NotNull List<Integer> intArray,
            @JsonProperty("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @JsonProperty("float_array") @NotNull List<Float> floatArray,
            @JsonProperty("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @JsonProperty("string_array") @NotNull List<String> stringArray,
            @JsonProperty("nullable_string_array") @Nullable List<String> nullableStringArray,
            @JsonProperty("mixed_array") @NotNull List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @JsonProperty("thing_array") @NotNull List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") @Nullable List<Object> nullArray,
            @JsonProperty("objects_array") @NotNull List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") @NotNull String text
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.List;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("empty_array") @NonNull List<Object> emptyArray,
            @JsonProperty("int_array") @NonNull List<Integer> intArray,
            @JsonProperty("nullable_int_array") List<Integer> nullableIntArray,
            @JsonProperty("float_array") @NonNull List<Float> floatArray,
            @JsonProperty("nullable_float_array") List<Float> nullableFloatArray,
            @JsonProperty("string_array") @NonNull List<String> stringArray,
            @JsonProperty("nullable_string_array") List<String> nullableStringArray,
            @JsonProperty("mixed_array") @NonNull List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") List<Object> nullableMixedArray,
            @JsonProperty("thing_array") @NonNull List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") List<Object> nullArray,
            @JsonProperty("objects_array") @NonNull List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") @NonNull String text
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("empty_array") @Nonnull List<Object> emptyArray,
            @JsonProperty("int_array") @Nonnull List<Integer> intArray,
            @JsonProperty("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @JsonProperty("float_array") @Nonnull List<Float> floatArray,
            @JsonProperty("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @JsonProperty("string_array") @Nonnull List<String> stringArray,
            @JsonProperty("nullable_string_array") @Nullable List<String> nullableStringArray,
            @JsonProperty("mixed_array") @Nonnull List<Object> mixedArray,
            @JsonProperty("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @JsonProperty("thing_array") @Nonnull List<ThingArray> thingArray,
            @JsonProperty("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @JsonProperty("null_array") @Nullable List<Object> nullArray,
            @JsonProperty("objects_array") @Nonnull List<Object> objectsArray,
            @JsonProperty("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @JsonProperty("text") @Nonnull String text
        ) {}

        public record NullableThingArray(
            @JsonProperty("text") @Nonnull String text
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.List;

        public record Root(
            @SerializedName("empty_array") List<Object> emptyArray,
            @SerializedName("int_array") List<Integer> intArray,
            @SerializedName("nullable_int_array") List<Integer> nullableIntArray,
            @SerializedName("float_array") List<Float> floatArray,
            @SerializedName("nullable_float_array") List<Float> nullableFloatArray,
            @SerializedName("string_array") List<String> stringArray,
            @SerializedName("nullable_string_array") List<String> nullableStringArray,
            @SerializedName("mixed_array") List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") List<Object> nullableMixedArray,
            @SerializedName("thing_array") List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") List<Object> nullArray,
            @SerializedName("objects_array") List<Object> objectsArray,
            @SerializedName("nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") String text
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.List;

        public record Root(
            @SerializedName("empty_array") @NotNull List<Object> emptyArray,
            @SerializedName("int_array") @NotNull List<Integer> intArray,
            @SerializedName("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @SerializedName("float_array") @NotNull List<Float> floatArray,
            @SerializedName("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @SerializedName("string_array") @NotNull List<String> stringArray,
            @SerializedName("nullable_string_array") @Nullable List<String> nullableStringArray,
            @SerializedName("mixed_array") @NotNull List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @SerializedName("thing_array") @NotNull List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") @Nullable List<Object> nullArray,
            @SerializedName("objects_array") @NotNull List<Object> objectsArray,
            @SerializedName("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") @NotNull String text
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("empty_array") @NonNull List<Object> emptyArray,
            @SerializedName("int_array") @NonNull List<Integer> intArray,
            @SerializedName("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @SerializedName("float_array") @NonNull List<Float> floatArray,
            @SerializedName("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @SerializedName("string_array") @NonNull List<String> stringArray,
            @SerializedName("nullable_string_array") @Nullable List<String> nullableStringArray,
            @SerializedName("mixed_array") @NonNull List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @SerializedName("thing_array") @NonNull List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") @Nullable List<Object> nullArray,
            @SerializedName("objects_array") @NonNull List<Object> objectsArray,
            @SerializedName("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") @NonNull String text
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("empty_array") @NotNull List<Object> emptyArray,
            @SerializedName("int_array") @NotNull List<Integer> intArray,
            @SerializedName("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @SerializedName("float_array") @NotNull List<Float> floatArray,
            @SerializedName("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @SerializedName("string_array") @NotNull List<String> stringArray,
            @SerializedName("nullable_string_array") @Nullable List<String> nullableStringArray,
            @SerializedName("mixed_array") @NotNull List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @SerializedName("thing_array") @NotNull List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") @Nullable List<Object> nullArray,
            @SerializedName("objects_array") @NotNull List<Object> objectsArray,
            @SerializedName("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") @NotNull String text
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.List;
        import lombok.NonNull;

        public record Root(
            @SerializedName("empty_array") @NonNull List<Object> emptyArray,
            @SerializedName("int_array") @NonNull List<Integer> intArray,
            @SerializedName("nullable_int_array") List<Integer> nullableIntArray,
            @SerializedName("float_array") @NonNull List<Float> floatArray,
            @SerializedName("nullable_float_array") List<Float> nullableFloatArray,
            @SerializedName("string_array") @NonNull List<String> stringArray,
            @SerializedName("nullable_string_array") List<String> nullableStringArray,
            @SerializedName("mixed_array") @NonNull List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") List<Object> nullableMixedArray,
            @SerializedName("thing_array") @NonNull List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") List<Object> nullArray,
            @SerializedName("objects_array") @NonNull List<Object> objectsArray,
            @SerializedName("nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") @NonNull String text
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("empty_array") @Nonnull List<Object> emptyArray,
            @SerializedName("int_array") @Nonnull List<Integer> intArray,
            @SerializedName("nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @SerializedName("float_array") @Nonnull List<Float> floatArray,
            @SerializedName("nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @SerializedName("string_array") @Nonnull List<String> stringArray,
            @SerializedName("nullable_string_array") @Nullable List<String> nullableStringArray,
            @SerializedName("mixed_array") @Nonnull List<Object> mixedArray,
            @SerializedName("nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @SerializedName("thing_array") @Nonnull List<ThingArray> thingArray,
            @SerializedName("nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @SerializedName("null_array") @Nullable List<Object> nullArray,
            @SerializedName("objects_array") @Nonnull List<Object> objectsArray,
            @SerializedName("nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @SerializedName("text") @Nonnull String text
        ) {}

        public record NullableThingArray(
            @SerializedName("text") @Nonnull String text
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;
        import java.util.List;

        public record Root(
            @Json(name = "empty_array") List<Object> emptyArray,
            @Json(name = "int_array") List<Integer> intArray,
            @Json(name = "nullable_int_array") List<Integer> nullableIntArray,
            @Json(name = "float_array") List<Float> floatArray,
            @Json(name = "nullable_float_array") List<Float> nullableFloatArray,
            @Json(name = "string_array") List<String> stringArray,
            @Json(name = "nullable_string_array") List<String> nullableStringArray,
            @Json(name = "mixed_array") List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") List<Object> nullableMixedArray,
            @Json(name = "thing_array") List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") List<Object> nullArray,
            @Json(name = "objects_array") List<Object> objectsArray,
            @Json(name = "nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") String text
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.util.List;

        public record Root(
            @Json(name = "empty_array") @NotNull List<Object> emptyArray,
            @Json(name = "int_array") @NotNull List<Integer> intArray,
            @Json(name = "nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @Json(name = "float_array") @NotNull List<Float> floatArray,
            @Json(name = "nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @Json(name = "string_array") @NotNull List<String> stringArray,
            @Json(name = "nullable_string_array") @Nullable List<String> nullableStringArray,
            @Json(name = "mixed_array") @NotNull List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @Json(name = "thing_array") @NotNull List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") @Nullable List<Object> nullArray,
            @Json(name = "objects_array") @NotNull List<Object> objectsArray,
            @Json(name = "nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") @NotNull String text
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import java.util.List;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "empty_array") @NonNull List<Object> emptyArray,
            @Json(name = "int_array") @NonNull List<Integer> intArray,
            @Json(name = "nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @Json(name = "float_array") @NonNull List<Float> floatArray,
            @Json(name = "nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @Json(name = "string_array") @NonNull List<String> stringArray,
            @Json(name = "nullable_string_array") @Nullable List<String> nullableStringArray,
            @Json(name = "mixed_array") @NonNull List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @Json(name = "thing_array") @NonNull List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") @Nullable List<Object> nullArray,
            @Json(name = "objects_array") @NonNull List<Object> objectsArray,
            @Json(name = "nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") @NonNull String text
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.util.List;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "empty_array") @NotNull List<Object> emptyArray,
            @Json(name = "int_array") @NotNull List<Integer> intArray,
            @Json(name = "nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @Json(name = "float_array") @NotNull List<Float> floatArray,
            @Json(name = "nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @Json(name = "string_array") @NotNull List<String> stringArray,
            @Json(name = "nullable_string_array") @Nullable List<String> nullableStringArray,
            @Json(name = "mixed_array") @NotNull List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @Json(name = "thing_array") @NotNull List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") @Nullable List<Object> nullArray,
            @Json(name = "objects_array") @NotNull List<Object> objectsArray,
            @Json(name = "nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") @NotNull String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") @NotNull String text
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import java.util.List;
        import lombok.NonNull;

        public record Root(
            @Json(name = "empty_array") @NonNull List<Object> emptyArray,
            @Json(name = "int_array") @NonNull List<Integer> intArray,
            @Json(name = "nullable_int_array") List<Integer> nullableIntArray,
            @Json(name = "float_array") @NonNull List<Float> floatArray,
            @Json(name = "nullable_float_array") List<Float> nullableFloatArray,
            @Json(name = "string_array") @NonNull List<String> stringArray,
            @Json(name = "nullable_string_array") List<String> nullableStringArray,
            @Json(name = "mixed_array") @NonNull List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") List<Object> nullableMixedArray,
            @Json(name = "thing_array") @NonNull List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") List<Object> nullArray,
            @Json(name = "objects_array") @NonNull List<Object> objectsArray,
            @Json(name = "nullable_objects_array") List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") @NonNull String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") @NonNull String text
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.util.List;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "empty_array") @Nonnull List<Object> emptyArray,
            @Json(name = "int_array") @Nonnull List<Integer> intArray,
            @Json(name = "nullable_int_array") @Nullable List<Integer> nullableIntArray,
            @Json(name = "float_array") @Nonnull List<Float> floatArray,
            @Json(name = "nullable_float_array") @Nullable List<Float> nullableFloatArray,
            @Json(name = "string_array") @Nonnull List<String> stringArray,
            @Json(name = "nullable_string_array") @Nullable List<String> nullableStringArray,
            @Json(name = "mixed_array") @Nonnull List<Object> mixedArray,
            @Json(name = "nullable_mixed_array") @Nullable List<Object> nullableMixedArray,
            @Json(name = "thing_array") @Nonnull List<ThingArray> thingArray,
            @Json(name = "nullable_thing_array") @Nullable List<NullableThingArray> nullableThingArray,
            @Json(name = "null_array") @Nullable List<Object> nullArray,
            @Json(name = "objects_array") @Nonnull List<Object> objectsArray,
            @Json(name = "nullable_objects_array") @Nullable List<Object> nullableObjectsArray
        ) {}

        public record ThingArray(
            @Json(name = "text") @Nonnull String text
        ) {}

        public record NullableThingArray(
            @Json(name = "text") @Nonnull String text
        ) {}
        """;
}