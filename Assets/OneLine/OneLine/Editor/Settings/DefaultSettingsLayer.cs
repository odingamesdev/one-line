﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneLine.Settings {
    public class DefaultSettingsLayer : ISettings {
        public TernaryBoolean Enabled { 
            get { return TernaryBoolean.TRUE; } 
        }

        public TernaryBoolean DrawVerticalSeparator {
            get { return TernaryBoolean.TRUE; }
        }

        public TernaryBoolean DrawHorizontalSeparator {
            get { return TernaryBoolean.TRUE; }
        }

        public TernaryBoolean Expandable {
            get { return TernaryBoolean.TRUE; }
        }
    }
}