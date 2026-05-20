using OperatorScriptWpf.Models;

namespace OperatorScriptWpf.Services;

public sealed class ScriptService
{
    public IReadOnlyDictionary<string, ScriptStepDefinition> LoadPresentationScript()
    {
        var steps = new List<ScriptStepDefinition>
               {
            new()
            {
                Id = "start",
                Theme = "",
                TextTemplate = """
                Здравствуйте, меня зовут {OperatorName}, я представляю компанию.
                Я разговариваю с {ClientName}?
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Да", NextStepId = "ready" },
                    new ScriptAnswer { Text = "Нет", NextStepId = "wrong-client" }
                ]
            },

            new()
            {
                Id = "wrong-client",
                Theme = "",
                TextTemplate = """
                Извините, пожалуйста. Подскажите, когда можно будет связаться с клиентом?
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Сообщает время", NextStepId = "callback" },
                    new ScriptAnswer { Text = "Не сообщает время", NextStepId = "finish-no-time" }
                ]
            },

            new()
            {
                Id = "ready",
                Theme = "",
                TextTemplate = """
                Очень приятно, {ClientName}. Вы готовы уделить мне 2-3 минуты
                и ответить на пару вопросов?
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Да", NextStepId = "offer" },
                    new ScriptAnswer { Text = "Нет", NextStepId = "ask-callback" }
                ]
            },

            new()
            {
                Id = "ask-callback",
                Theme = "",
                TextTemplate = """
                Подскажите, пожалуйста, когда можно будет перезвонить,
                чтобы поговорить с вами?
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Сообщает время", NextStepId = "callback" },
                    new ScriptAnswer { Text = "Не сообщает время", NextStepId = "finish-no-time" }
                ]
            },

            new()
            {
                Id = "offer",
                Theme = "",
                TextTemplate = """
                {ClientName}, спасибо, что являетесь нашим клиентом.

                Сейчас я кратко расскажу условия программы.
                При наступлении страхового случая клиент может получить выплату
                по условиям программы. После этого я задам уточняющий вопрос.
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Продолжить", NextStepId = "price" },
                    new ScriptAnswer { Text = "Отказ", NextStepId = "reject" }
                ]
            },

            new()
            {
                Id = "price",
                Theme = "",
                TextTemplate = """
                Плата за услугу составляет фиксированную часть от суммы задолженности.
                Важно объяснить клиенту условия спокойно и без давления.

                Готовы продолжить оформление?
                """,
                Answers =
                [
                    new ScriptAnswer { Text = "Да", NextStepId = "success" },
                    new ScriptAnswer { Text = "Нет", NextStepId = "reject" }
                ]
            },

            new()
            {
                Id = "success",
                Theme = "",
                TextTemplate = """
                Отлично. Перейдите во вкладку «Дозвон, Успешно»
                и завершите задачу по инструкции.
                """,
                Answers = []
            },

            new()
            {
                Id = "reject",
                Theme = "",
                TextTemplate = """
                Клиент отказался от продолжения.
                Перейдите во вкладку «Дозвон, Отказ»
                и завершите задачу по инструкции.
                """,
                Answers = []
            },

            new()
            {
                Id = "callback",
                Theme = "",
                TextTemplate = """
                Зафиксируйте время перезвона.
                Перейдите во вкладку «Перезвон».
                """,
                Answers = []
            },

            new()
            {
                Id = "finish-no-time",
                Theme = "",
                TextTemplate = """
                Клиент не сообщил удобное время.
                Завершите задачу согласно внутренней инструкции.
                """,
                Answers = []
            }
        };

        return steps.ToDictionary(x => x.Id);
    }
    
}