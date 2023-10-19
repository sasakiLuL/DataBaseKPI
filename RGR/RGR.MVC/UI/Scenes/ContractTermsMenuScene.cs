﻿using RGR.MVC.Controlers;
using Spectre.Console;

namespace RGR.MVC.UI.Scenes
{
    public class ContractTermsMenuScene : TableScene
    {
        public override SceneType Type => SceneType.ContractTermsMenu;

        public ContractTermsController Controller { get; set; }

        public ContractTermsMenuScene(UISettings settings, ContractTermsController controller) : base(settings)
        {
            Controller = controller;
        }

        public override SceneType Render()
        {
            switch (GetPrompt())
            {
                case "Find all":
                    Controller.PrintAllContractsTerms();
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractTermsMenu;

                case "Add":
                    Controller.AddContractTerms(
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]contract name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<decimal>($"Enter [{Settings.HeaderColor}]price[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]description[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 2000)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]gym id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractTermsMenu;

                case "Update":
                    Controller.UpdateContractTerms(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]contract name[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .Validate(v =>
                            {
                                if (v.Length <= 100)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<decimal>($"Enter [{Settings.HeaderColor}]price[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<string>($"Enter [{Settings.HeaderColor}]description[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                            .AllowEmpty()
                            .Validate(v =>
                            {
                                if (v.Length <= 2000)
                                    return ValidationResult.Success();
                                return ValidationResult.Error("String should be not longer than 100");
                            })
                        ),
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter [{Settings.HeaderColor}]gym id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractTermsMenu;

                case "Delete":
                    Controller.DeleteContractTerms(
                        AnsiConsole.Prompt(
                            new TextPrompt<long>($"Enter class[{Settings.HeaderColor}] id[/]:")
                            .PromptStyle(Settings.HeaderColor)
                            .ValidationErrorMessage("That's not a valid value!")
                        )
                    );
                    AnsiConsole.Prompt(
                        new TextPrompt<string>("Press to continue...").AllowEmpty()
                    );
                    AnsiConsole.Clear();
                    return SceneType.ContractTermsMenu;

                default:
                    return SceneType.StartMenu;
            };
        }
    }
}
