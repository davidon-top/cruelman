using System;
using System.Collections.Generic;
using CruelMan.Modules;
using CruelMan.Modules.Settings;
using UnityEngine;

namespace CruelMan.UI {
    public class MainUI : MonoBehaviour {
        public bool menuOpen = false;

        public List<Setting> openSettings = null;
        public Module openSettingsModule = null;
        public Rect settingsWindow = new Rect(140, 10, 220, 600);

        public Rect ModuleMovementWindow = new Rect(10, 10, 200, 500);
        public Rect ModuleStatsWindow = new Rect(220, 10, 200, 500);
        public Rect ModuleCombatWindow = new Rect(440, 10, 200, 500);
        public Rect ModuleMiscWindow = new Rect(660, 10, 200, 500);

        public void OnGUI() {
            if (!menuOpen) {
                return;
            }

            // windowRect = GUI.Window(0, windowRect, MainWindow, "CruelMan");
            ModuleMovementWindow = GUI.Window(0, ModuleMovementWindow, MainWindow, "Movement");
            ModuleStatsWindow = GUI.Window(1, ModuleStatsWindow, MainWindow, "Stats");
            ModuleCombatWindow = GUI.Window(2, ModuleCombatWindow, MainWindow, "Combat");
            ModuleMiscWindow = GUI.Window(3, ModuleMiscWindow, MainWindow, "Misc");

            if (openSettings != null) {
                 settingsWindow = GUI.Window(99, settingsWindow, SettingsWindow, openSettingsModule.Name);
            }
        }

        public void MainWindow(int windowID) {
            ModuleType mt = (ModuleType)windowID;

            int lastY = 20;
            
            foreach (Module module in ModuleManager.instance.modules) {
                if (module.Type == mt) {
                    if (module.Enabled) {
                        GUI.color = Color.green;
                    } else {
                        GUI.color = Color.red;
                    }
                    if (GUI.Button(new Rect(10, lastY, 150, 20), module.Name)) {
                        module.Toggle();
                    }
                    if (GUI.Button(new Rect(160, lastY, 20, 20), "S")) {
                        if (openSettingsModule == module) {
                            openSettingsModule.Refresh();
                            openSettingsModule = null;
                            openSettings = null;
                        } else {
                            openSettingsModule = module;
                            openSettings = module.Settings;
                        }
                    }
                    GUI.color = Color.white;
                    lastY += 20;
                }
            }

            GUI.DragWindow(new Rect(0, 0, 10000, 10000));
        }

        public void SettingsWindow(int windowID) {
            if (GUI.Button(new Rect(10, 20, 95, 20), "Apply")) {
                openSettingsModule.Refresh();
                openSettingsModule = null;
                openSettings = null;
            }

            openSettingsModule.bind = (KeyCode)Enum.Parse(typeof(KeyCode), GUI.TextField(new Rect(105, 20, 95, 20), openSettingsModule.bind.ToString()));

            int lastY = 70;

            foreach (Setting setting in openSettings) {
                if (setting is BooleanSetting) {
                    BooleanSetting bs = (BooleanSetting)setting;
                    bs.Value = GUI.Toggle(new Rect(10, lastY, 100, 20), bs.Value, bs.Name);
                    lastY += 20;
                } else if (setting is NumberSetting) {
                    NumberSetting ns = (NumberSetting)setting;
                    ns.Value = GUI.HorizontalSlider(new Rect(10, lastY, 100, 20), ns.Value, ns.Min, ns.Max);
                    lastY += 20;
                } else if (setting is TextSetting) {
                    TextSetting ts = (TextSetting)setting;
                    ts.value = GUI.TextField(new Rect(10, lastY, 100, 20), ts.value);
                    lastY += 20;
                } else if (setting is ActionSetting) {
                    ActionSetting as_ = (ActionSetting)setting;
                    if (GUI.Button(new Rect(10, lastY, 100, 20), as_.Name)) {
                        as_.Run(openSettingsModule);
                    }
                    lastY += 20;
                }
            }

            GUI.DragWindow(new Rect(0, 0, 10000, 10000));
        }

        public void ToggleMenu() {
            menuOpen = !menuOpen;
        }
    }
}
