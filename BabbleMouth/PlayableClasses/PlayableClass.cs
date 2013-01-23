﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BabbleMouth.PlayableClasses {
    public abstract class PlayableClass {
        public enum PlayableClassEnum {
            DEATH_KNIGHT,
            DRUID,
            HUNTER,
            MAGE,
            MONK,
            PALADIN,
            PRIEST,
            ROGUE,
            SHAMAN,
            WARLOCK,
            WARRIOR
        }
        public string Name { get; set; }
        public Dictionary<string, int> Abilities { get; set; }
        public List<string[]> PlayerLogs = new List<string[]>();
        private string SpellCastSuccess = "SPELL_CAST_SUCCESS";
        //private string UnitDied = "UNIT_DIED";

        public PlayableClass() {
        try {
            Abilities = new Dictionary<string, int>();
        } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void ParseLines() {
        try {
            PlayerLogs.ForEach(line => {
                string ability = line[0].Trim() == SpellCastSuccess ? line[10].Replace('"', ' ').Trim() : string.Empty;
                if (ConfigurationManager.AppSettings.AllKeys.Contains(ability)) {
                    if (!Abilities.ContainsKey(ability)) Abilities.Add(ability, 1);
                    else Abilities[ability]++;
                }
                //if (line[0].Trim() == UnitDied) {
                //    uint index = (uint)PlayerLogs.IndexOf(line);
                //    for (uint i = index - 50; i < index; i++) {

                //    }
                //}
            });
        } catch (Exception ex) { throw ex; }
        }

    }
}
