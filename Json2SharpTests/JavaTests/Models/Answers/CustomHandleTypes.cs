namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class CustomHandleTypes
{
    public const string Input = """
        {
            "id": "550e8400-e29b-41d4-a716-446655440000",
            "date": "2021-01-01T00:00:00Z",
            "duration": "00:00:01",
            "null_thing": null,
            "empty_thing": {},
            "thing": [
                {
                    "text": "hello world",
                    "number": 1,
                    "int_array": [ 1, 2, 3 ],
                    "prop_base:colon": 2,
                    "prop_custom:colon": { "blep": "nested" }
                }
            ]
        }
        """;

    public const string NoAnnotationOutput = """
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            private UUID id;
        
            private OffsetDateTime date;
        
            private Duration duration;
        
            private Object nullThing;
        
            private Object emptyThing;
        
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            private String text;
        
            private Integer number;
        
            private List<Integer> intArray = new ArrayList<>();
        
            private Integer propBaseColon;
        
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @JsonProperty("id")
            private UUID id;
        
            @JsonProperty("date")
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            private Duration duration;
        
            @JsonProperty("null_thing")
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            private Object emptyThing;
        
            @JsonProperty("thing")
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @JsonProperty("text")
            private String text;
        
            @JsonProperty("number")
            private Integer number;
        
            @JsonProperty("int_array")
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @JsonProperty("blep")
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @JsonProperty("id")
            @NotNull
            private UUID id;
        
            @JsonProperty("date")
            @NotNull
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            @NotNull
            private Duration duration;
        
            @JsonProperty("null_thing")
            @Nullable
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            @NotNull
            private Object emptyThing;
        
            @JsonProperty("thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @JsonProperty("text")
            @NotNull
            private String text;
        
            @JsonProperty("number")
            @NotNull
            private Integer number;
        
            @JsonProperty("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @JsonProperty("blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public class custom_handle_types {
            @JsonProperty("id")
            @NonNull
            private UUID id;
        
            @JsonProperty("date")
            @NonNull
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            @NonNull
            private Duration duration;
        
            @JsonProperty("null_thing")
            @Nullable
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            @NonNull
            private Object emptyThing;
        
            @JsonProperty("thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @JsonProperty("text")
            @NonNull
            private String text;
        
            @JsonProperty("number")
            @NonNull
            private Integer number;
        
            @JsonProperty("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @JsonProperty("blep")
            @NonNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public class custom_handle_types {
            @JsonProperty("id")
            @NotNull
            private UUID id;
        
            @JsonProperty("date")
            @NotNull
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            @NotNull
            private Duration duration;
        
            @JsonProperty("null_thing")
            @Nullable
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            @NotNull
            private Object emptyThing;
        
            @JsonProperty("thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @JsonProperty("text")
            @NotNull
            private String text;
        
            @JsonProperty("number")
            @NotNull
            private Integer number;
        
            @JsonProperty("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @JsonProperty("blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;
        
        @Data
        public class custom_handle_types {
            @JsonProperty("id")
            @NonNull
            private UUID id;
        
            @JsonProperty("date")
            @NonNull
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            @NonNull
            private Duration duration;
        
            @JsonProperty("null_thing")
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            @NonNull
            private Object emptyThing;
        
            @JsonProperty("thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        }
        
        @Data
        public class thing {
            @JsonProperty("text")
            @NonNull
            private String text;
        
            @JsonProperty("number")
            @NonNull
            private Integer number;
        
            @JsonProperty("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        }
        
        @Data
        public class prop_custom_colon {
            @JsonProperty("blep")
            @NonNull
            private String blep;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public class custom_handle_types {
            @JsonProperty("id")
            @Nonnull
            private UUID id;
        
            @JsonProperty("date")
            @Nonnull
            private OffsetDateTime date;
        
            @JsonProperty("duration")
            @Nonnull
            private Duration duration;
        
            @JsonProperty("null_thing")
            @Nullable
            private Object nullThing;
        
            @JsonProperty("empty_thing")
            @Nonnull
            private Object emptyThing;
        
            @JsonProperty("thing")
            @Nonnull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @JsonProperty("text")
            @Nonnull
            private String text;
        
            @JsonProperty("number")
            @Nonnull
            private Integer number;
        
            @JsonProperty("int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();
        
            @JsonProperty("prop_base:colon")
            @Nonnull
            private Integer propBaseColon;
        
            @JsonProperty("prop_custom:colon")
            @Nonnull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @JsonProperty("blep")
            @Nonnull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @SerializedName("id")
            private UUID id;
        
            @SerializedName("date")
            private OffsetDateTime date;
        
            @SerializedName("duration")
            private Duration duration;
        
            @SerializedName("null_thing")
            private Object nullThing;
        
            @SerializedName("empty_thing")
            private Object emptyThing;
        
            @SerializedName("thing")
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @SerializedName("text")
            private String text;
        
            @SerializedName("number")
            private Integer number;
        
            @SerializedName("int_array")
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @SerializedName("blep")
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @SerializedName("id")
            @NotNull
            private UUID id;
        
            @SerializedName("date")
            @NotNull
            private OffsetDateTime date;
        
            @SerializedName("duration")
            @NotNull
            private Duration duration;
        
            @SerializedName("null_thing")
            @Nullable
            private Object nullThing;
        
            @SerializedName("empty_thing")
            @NotNull
            private Object emptyThing;
        
            @SerializedName("thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @SerializedName("text")
            @NotNull
            private String text;
        
            @SerializedName("number")
            @NotNull
            private Integer number;
        
            @SerializedName("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @SerializedName("blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public class custom_handle_types {
            @SerializedName("id")
            @NonNull
            private UUID id;
        
            @SerializedName("date")
            @NonNull
            private OffsetDateTime date;
        
            @SerializedName("duration")
            @NonNull
            private Duration duration;
        
            @SerializedName("null_thing")
            @Nullable
            private Object nullThing;
        
            @SerializedName("empty_thing")
            @NonNull
            private Object emptyThing;
        
            @SerializedName("thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @SerializedName("text")
            @NonNull
            private String text;
        
            @SerializedName("number")
            @NonNull
            private Integer number;
        
            @SerializedName("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @SerializedName("blep")
            @NonNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public class custom_handle_types {
            @SerializedName("id")
            @NotNull
            private UUID id;
        
            @SerializedName("date")
            @NotNull
            private OffsetDateTime date;
        
            @SerializedName("duration")
            @NotNull
            private Duration duration;
        
            @SerializedName("null_thing")
            @Nullable
            private Object nullThing;
        
            @SerializedName("empty_thing")
            @NotNull
            private Object emptyThing;
        
            @SerializedName("thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @SerializedName("text")
            @NotNull
            private String text;
        
            @SerializedName("number")
            @NotNull
            private Integer number;
        
            @SerializedName("int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @SerializedName("blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;
        
        @Data
        public class custom_handle_types {
            @SerializedName("id")
            @NonNull
            private UUID id;
        
            @SerializedName("date")
            @NonNull
            private OffsetDateTime date;
        
            @SerializedName("duration")
            @NonNull
            private Duration duration;
        
            @SerializedName("null_thing")
            private Object nullThing;
        
            @SerializedName("empty_thing")
            @NonNull
            private Object emptyThing;
        
            @SerializedName("thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        }
        
        @Data
        public class thing {
            @SerializedName("text")
            @NonNull
            private String text;
        
            @SerializedName("number")
            @NonNull
            private Integer number;
        
            @SerializedName("int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        }
        
        @Data
        public class prop_custom_colon {
            @SerializedName("blep")
            @NonNull
            private String blep;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public class custom_handle_types {
            @SerializedName("id")
            @Nonnull
            private UUID id;
        
            @SerializedName("date")
            @Nonnull
            private OffsetDateTime date;
        
            @SerializedName("duration")
            @Nonnull
            private Duration duration;
        
            @SerializedName("null_thing")
            @Nullable
            private Object nullThing;
        
            @SerializedName("empty_thing")
            @Nonnull
            private Object emptyThing;
        
            @SerializedName("thing")
            @Nonnull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @SerializedName("text")
            @Nonnull
            private String text;
        
            @SerializedName("number")
            @Nonnull
            private Integer number;
        
            @SerializedName("int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();
        
            @SerializedName("prop_base:colon")
            @Nonnull
            private Integer propBaseColon;
        
            @SerializedName("prop_custom:colon")
            @Nonnull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @SerializedName("blep")
            @Nonnull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @Json(name = "id")
            private UUID id;
        
            @Json(name = "date")
            private OffsetDateTime date;
        
            @Json(name = "duration")
            private Duration duration;
        
            @Json(name = "null_thing")
            private Object nullThing;
        
            @Json(name = "empty_thing")
            private Object emptyThing;
        
            @Json(name = "thing")
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @Json(name = "text")
            private String text;
        
            @Json(name = "number")
            private Integer number;
        
            @Json(name = "int_array")
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @Json(name = "blep")
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        
        public class custom_handle_types {
            @Json(name = "id")
            @NotNull
            private UUID id;
        
            @Json(name = "date")
            @NotNull
            private OffsetDateTime date;
        
            @Json(name = "duration")
            @NotNull
            private Duration duration;
        
            @Json(name = "null_thing")
            @Nullable
            private Object nullThing;
        
            @Json(name = "empty_thing")
            @NotNull
            private Object emptyThing;
        
            @Json(name = "thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @Json(name = "text")
            @NotNull
            private String text;
        
            @Json(name = "number")
            @NotNull
            private Integer number;
        
            @Json(name = "int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @Json(name = "blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public class custom_handle_types {
            @Json(name = "id")
            @NonNull
            private UUID id;
        
            @Json(name = "date")
            @NonNull
            private OffsetDateTime date;
        
            @Json(name = "duration")
            @NonNull
            private Duration duration;
        
            @Json(name = "null_thing")
            @Nullable
            private Object nullThing;
        
            @Json(name = "empty_thing")
            @NonNull
            private Object emptyThing;
        
            @Json(name = "thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @Json(name = "text")
            @NonNull
            private String text;
        
            @Json(name = "number")
            @NonNull
            private Integer number;
        
            @Json(name = "int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @Json(name = "blep")
            @NonNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public class custom_handle_types {
            @Json(name = "id")
            @NotNull
            private UUID id;
        
            @Json(name = "date")
            @NotNull
            private OffsetDateTime date;
        
            @Json(name = "duration")
            @NotNull
            private Duration duration;
        
            @Json(name = "null_thing")
            @Nullable
            private Object nullThing;
        
            @Json(name = "empty_thing")
            @NotNull
            private Object emptyThing;
        
            @Json(name = "thing")
            @NotNull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @Json(name = "text")
            @NotNull
            private String text;
        
            @Json(name = "number")
            @NotNull
            private Integer number;
        
            @Json(name = "int_array")
            @NotNull
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            @NotNull
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            @NotNull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @Json(name = "blep")
            @NotNull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;
        
        @Data
        public class custom_handle_types {
            @Json(name = "id")
            @NonNull
            private UUID id;
        
            @Json(name = "date")
            @NonNull
            private OffsetDateTime date;
        
            @Json(name = "duration")
            @NonNull
            private Duration duration;
        
            @Json(name = "null_thing")
            private Object nullThing;
        
            @Json(name = "empty_thing")
            @NonNull
            private Object emptyThing;
        
            @Json(name = "thing")
            @NonNull
            private List<thing> thing = new ArrayList<>();
        }
        
        @Data
        public class thing {
            @Json(name = "text")
            @NonNull
            private String text;
        
            @Json(name = "number")
            @NonNull
            private Integer number;
        
            @Json(name = "int_array")
            @NonNull
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            @NonNull
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            @NonNull
            private prop_custom_colon propCustomColon;
        }
        
        @Data
        public class prop_custom_colon {
            @Json(name = "blep")
            @NonNull
            private String blep;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.ArrayList;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public class custom_handle_types {
            @Json(name = "id")
            @Nonnull
            private UUID id;
        
            @Json(name = "date")
            @Nonnull
            private OffsetDateTime date;
        
            @Json(name = "duration")
            @Nonnull
            private Duration duration;
        
            @Json(name = "null_thing")
            @Nullable
            private Object nullThing;
        
            @Json(name = "empty_thing")
            @Nonnull
            private Object emptyThing;
        
            @Json(name = "thing")
            @Nonnull
            private List<thing> thing = new ArrayList<>();
        
            public UUID getId() {
                return id;
            }
        
            public void setId(UUID id) {
                this.id = id;
            }
        
            public OffsetDateTime getDate() {
                return date;
            }
        
            public void setDate(OffsetDateTime date) {
                this.date = date;
            }
        
            public Duration getDuration() {
                return duration;
            }
        
            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        
            public Object getNullThing() {
                return nullThing;
            }
        
            public void setNullThing(Object nullThing) {
                this.nullThing = nullThing;
            }
        
            public Object getEmptyThing() {
                return emptyThing;
            }
        
            public void setEmptyThing(Object emptyThing) {
                this.emptyThing = emptyThing;
            }
        
            public List<thing> getThing() {
                return thing;
            }
        
            public void setThing(List<thing> thing) {
                this.thing = thing;
            }
        }
        
        public class thing {
            @Json(name = "text")
            @Nonnull
            private String text;
        
            @Json(name = "number")
            @Nonnull
            private Integer number;
        
            @Json(name = "int_array")
            @Nonnull
            private List<Integer> intArray = new ArrayList<>();
        
            @Json(name = "prop_base:colon")
            @Nonnull
            private Integer propBaseColon;
        
            @Json(name = "prop_custom:colon")
            @Nonnull
            private prop_custom_colon propCustomColon;
        
            public String getText() {
                return text;
            }
        
            public void setText(String text) {
                this.text = text;
            }
        
            public Integer getNumber() {
                return number;
            }
        
            public void setNumber(Integer number) {
                this.number = number;
            }
        
            public List<Integer> getIntArray() {
                return intArray;
            }
        
            public void setIntArray(List<Integer> intArray) {
                this.intArray = intArray;
            }
        
            public Integer getPropBaseColon() {
                return propBaseColon;
            }
        
            public void setPropBaseColon(Integer propBaseColon) {
                this.propBaseColon = propBaseColon;
            }
        
            public prop_custom_colon getPropCustomColon() {
                return propCustomColon;
            }
        
            public void setPropCustomColon(prop_custom_colon propCustomColon) {
                this.propCustomColon = propCustomColon;
            }
        }
        
        public class prop_custom_colon {
            @Json(name = "blep")
            @Nonnull
            private String blep;
        
            public String getBlep() {
                return blep;
            }
        
            public void setBlep(String blep) {
                this.blep = blep;
            }
        }
        """;

    public const string NoAnnotationRecordOutput = """
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            UUID id,
            OffsetDateTime date,
            Duration duration,
            Object nullThing,
            Object emptyThing,
            List<thing> thing
        ) {}
        
        public record thing(
            String text,
            Integer number,
            List<Integer> intArray,
            Integer propBaseColon,
            prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            String blep
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @JsonProperty("id") UUID id,
            @JsonProperty("date") OffsetDateTime date,
            @JsonProperty("duration") Duration duration,
            @JsonProperty("null_thing") Object nullThing,
            @JsonProperty("empty_thing") Object emptyThing,
            @JsonProperty("thing") List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") String text,
            @JsonProperty("number") Integer number,
            @JsonProperty("int_array") List<Integer> intArray,
            @JsonProperty("prop_base:colon") Integer propBaseColon,
            @JsonProperty("prop_custom:colon") prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") String blep
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @JsonProperty("id") @NotNull UUID id,
            @JsonProperty("date") @NotNull OffsetDateTime date,
            @JsonProperty("duration") @NotNull Duration duration,
            @JsonProperty("null_thing") @Nullable Object nullThing,
            @JsonProperty("empty_thing") @NotNull Object emptyThing,
            @JsonProperty("thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") @NotNull String text,
            @JsonProperty("number") @NotNull Integer number,
            @JsonProperty("int_array") @NotNull List<Integer> intArray,
            @JsonProperty("prop_base:colon") @NotNull Integer propBaseColon,
            @JsonProperty("prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") @NotNull String blep
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public record custom_handle_types(
            @JsonProperty("id") @NonNull UUID id,
            @JsonProperty("date") @NonNull OffsetDateTime date,
            @JsonProperty("duration") @NonNull Duration duration,
            @JsonProperty("null_thing") @Nullable Object nullThing,
            @JsonProperty("empty_thing") @NonNull Object emptyThing,
            @JsonProperty("thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") @NonNull String text,
            @JsonProperty("number") @NonNull Integer number,
            @JsonProperty("int_array") @NonNull List<Integer> intArray,
            @JsonProperty("prop_base:colon") @NonNull Integer propBaseColon,
            @JsonProperty("prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") @NonNull String blep
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public record custom_handle_types(
            @JsonProperty("id") @NotNull UUID id,
            @JsonProperty("date") @NotNull OffsetDateTime date,
            @JsonProperty("duration") @NotNull Duration duration,
            @JsonProperty("null_thing") @Nullable Object nullThing,
            @JsonProperty("empty_thing") @NotNull Object emptyThing,
            @JsonProperty("thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") @NotNull String text,
            @JsonProperty("number") @NotNull Integer number,
            @JsonProperty("int_array") @NotNull List<Integer> intArray,
            @JsonProperty("prop_base:colon") @NotNull Integer propBaseColon,
            @JsonProperty("prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") @NotNull String blep
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import lombok.NonNull;
        
        public record custom_handle_types(
            @JsonProperty("id") @NonNull UUID id,
            @JsonProperty("date") @NonNull OffsetDateTime date,
            @JsonProperty("duration") @NonNull Duration duration,
            @JsonProperty("null_thing") Object nullThing,
            @JsonProperty("empty_thing") @NonNull Object emptyThing,
            @JsonProperty("thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") @NonNull String text,
            @JsonProperty("number") @NonNull Integer number,
            @JsonProperty("int_array") @NonNull List<Integer> intArray,
            @JsonProperty("prop_base:colon") @NonNull Integer propBaseColon,
            @JsonProperty("prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") @NonNull String blep
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public record custom_handle_types(
            @JsonProperty("id") @Nonnull UUID id,
            @JsonProperty("date") @Nonnull OffsetDateTime date,
            @JsonProperty("duration") @Nonnull Duration duration,
            @JsonProperty("null_thing") @Nullable Object nullThing,
            @JsonProperty("empty_thing") @Nonnull Object emptyThing,
            @JsonProperty("thing") @Nonnull List<thing> thing
        ) {}
        
        public record thing(
            @JsonProperty("text") @Nonnull String text,
            @JsonProperty("number") @Nonnull Integer number,
            @JsonProperty("int_array") @Nonnull List<Integer> intArray,
            @JsonProperty("prop_base:colon") @Nonnull Integer propBaseColon,
            @JsonProperty("prop_custom:colon") @Nonnull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @JsonProperty("blep") @Nonnull String blep
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @SerializedName("id") UUID id,
            @SerializedName("date") OffsetDateTime date,
            @SerializedName("duration") Duration duration,
            @SerializedName("null_thing") Object nullThing,
            @SerializedName("empty_thing") Object emptyThing,
            @SerializedName("thing") List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") String text,
            @SerializedName("number") Integer number,
            @SerializedName("int_array") List<Integer> intArray,
            @SerializedName("prop_base:colon") Integer propBaseColon,
            @SerializedName("prop_custom:colon") prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") String blep
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @SerializedName("id") @NotNull UUID id,
            @SerializedName("date") @NotNull OffsetDateTime date,
            @SerializedName("duration") @NotNull Duration duration,
            @SerializedName("null_thing") @Nullable Object nullThing,
            @SerializedName("empty_thing") @NotNull Object emptyThing,
            @SerializedName("thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") @NotNull String text,
            @SerializedName("number") @NotNull Integer number,
            @SerializedName("int_array") @NotNull List<Integer> intArray,
            @SerializedName("prop_base:colon") @NotNull Integer propBaseColon,
            @SerializedName("prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") @NotNull String blep
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public record custom_handle_types(
            @SerializedName("id") @NonNull UUID id,
            @SerializedName("date") @NonNull OffsetDateTime date,
            @SerializedName("duration") @NonNull Duration duration,
            @SerializedName("null_thing") @Nullable Object nullThing,
            @SerializedName("empty_thing") @NonNull Object emptyThing,
            @SerializedName("thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") @NonNull String text,
            @SerializedName("number") @NonNull Integer number,
            @SerializedName("int_array") @NonNull List<Integer> intArray,
            @SerializedName("prop_base:colon") @NonNull Integer propBaseColon,
            @SerializedName("prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") @NonNull String blep
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public record custom_handle_types(
            @SerializedName("id") @NotNull UUID id,
            @SerializedName("date") @NotNull OffsetDateTime date,
            @SerializedName("duration") @NotNull Duration duration,
            @SerializedName("null_thing") @Nullable Object nullThing,
            @SerializedName("empty_thing") @NotNull Object emptyThing,
            @SerializedName("thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") @NotNull String text,
            @SerializedName("number") @NotNull Integer number,
            @SerializedName("int_array") @NotNull List<Integer> intArray,
            @SerializedName("prop_base:colon") @NotNull Integer propBaseColon,
            @SerializedName("prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") @NotNull String blep
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import lombok.NonNull;
        
        public record custom_handle_types(
            @SerializedName("id") @NonNull UUID id,
            @SerializedName("date") @NonNull OffsetDateTime date,
            @SerializedName("duration") @NonNull Duration duration,
            @SerializedName("null_thing") Object nullThing,
            @SerializedName("empty_thing") @NonNull Object emptyThing,
            @SerializedName("thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") @NonNull String text,
            @SerializedName("number") @NonNull Integer number,
            @SerializedName("int_array") @NonNull List<Integer> intArray,
            @SerializedName("prop_base:colon") @NonNull Integer propBaseColon,
            @SerializedName("prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") @NonNull String blep
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public record custom_handle_types(
            @SerializedName("id") @Nonnull UUID id,
            @SerializedName("date") @Nonnull OffsetDateTime date,
            @SerializedName("duration") @Nonnull Duration duration,
            @SerializedName("null_thing") @Nullable Object nullThing,
            @SerializedName("empty_thing") @Nonnull Object emptyThing,
            @SerializedName("thing") @Nonnull List<thing> thing
        ) {}
        
        public record thing(
            @SerializedName("text") @Nonnull String text,
            @SerializedName("number") @Nonnull Integer number,
            @SerializedName("int_array") @Nonnull List<Integer> intArray,
            @SerializedName("prop_base:colon") @Nonnull Integer propBaseColon,
            @SerializedName("prop_custom:colon") @Nonnull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @SerializedName("blep") @Nonnull String blep
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @Json(name = "id") UUID id,
            @Json(name = "date") OffsetDateTime date,
            @Json(name = "duration") Duration duration,
            @Json(name = "null_thing") Object nullThing,
            @Json(name = "empty_thing") Object emptyThing,
            @Json(name = "thing") List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") String text,
            @Json(name = "number") Integer number,
            @Json(name = "int_array") List<Integer> intArray,
            @Json(name = "prop_base:colon") Integer propBaseColon,
            @Json(name = "prop_custom:colon") prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") String blep
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        
        public record custom_handle_types(
            @Json(name = "id") @NotNull UUID id,
            @Json(name = "date") @NotNull OffsetDateTime date,
            @Json(name = "duration") @NotNull Duration duration,
            @Json(name = "null_thing") @Nullable Object nullThing,
            @Json(name = "empty_thing") @NotNull Object emptyThing,
            @Json(name = "thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") @NotNull String text,
            @Json(name = "number") @NotNull Integer number,
            @Json(name = "int_array") @NotNull List<Integer> intArray,
            @Json(name = "prop_base:colon") @NotNull Integer propBaseColon,
            @Json(name = "prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") @NotNull String blep
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;
        
        public record custom_handle_types(
            @Json(name = "id") @NonNull UUID id,
            @Json(name = "date") @NonNull OffsetDateTime date,
            @Json(name = "duration") @NonNull Duration duration,
            @Json(name = "null_thing") @Nullable Object nullThing,
            @Json(name = "empty_thing") @NonNull Object emptyThing,
            @Json(name = "thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") @NonNull String text,
            @Json(name = "number") @NonNull Integer number,
            @Json(name = "int_array") @NonNull List<Integer> intArray,
            @Json(name = "prop_base:colon") @NonNull Integer propBaseColon,
            @Json(name = "prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") @NonNull String blep
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;
        
        public record custom_handle_types(
            @Json(name = "id") @NotNull UUID id,
            @Json(name = "date") @NotNull OffsetDateTime date,
            @Json(name = "duration") @NotNull Duration duration,
            @Json(name = "null_thing") @Nullable Object nullThing,
            @Json(name = "empty_thing") @NotNull Object emptyThing,
            @Json(name = "thing") @NotNull List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") @NotNull String text,
            @Json(name = "number") @NotNull Integer number,
            @Json(name = "int_array") @NotNull List<Integer> intArray,
            @Json(name = "prop_base:colon") @NotNull Integer propBaseColon,
            @Json(name = "prop_custom:colon") @NotNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") @NotNull String blep
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import lombok.NonNull;
        
        public record custom_handle_types(
            @Json(name = "id") @NonNull UUID id,
            @Json(name = "date") @NonNull OffsetDateTime date,
            @Json(name = "duration") @NonNull Duration duration,
            @Json(name = "null_thing") Object nullThing,
            @Json(name = "empty_thing") @NonNull Object emptyThing,
            @Json(name = "thing") @NonNull List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") @NonNull String text,
            @Json(name = "number") @NonNull Integer number,
            @Json(name = "int_array") @NonNull List<Integer> intArray,
            @Json(name = "prop_base:colon") @NonNull Integer propBaseColon,
            @Json(name = "prop_custom:colon") @NonNull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") @NonNull String blep
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.List;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;
        
        public record custom_handle_types(
            @Json(name = "id") @Nonnull UUID id,
            @Json(name = "date") @Nonnull OffsetDateTime date,
            @Json(name = "duration") @Nonnull Duration duration,
            @Json(name = "null_thing") @Nullable Object nullThing,
            @Json(name = "empty_thing") @Nonnull Object emptyThing,
            @Json(name = "thing") @Nonnull List<thing> thing
        ) {}
        
        public record thing(
            @Json(name = "text") @Nonnull String text,
            @Json(name = "number") @Nonnull Integer number,
            @Json(name = "int_array") @Nonnull List<Integer> intArray,
            @Json(name = "prop_base:colon") @Nonnull Integer propBaseColon,
            @Json(name = "prop_custom:colon") @Nonnull prop_custom_colon propCustomColon
        ) {}
        
        public record prop_custom_colon(
            @Json(name = "blep") @Nonnull String blep
        ) {}
        """;

}
