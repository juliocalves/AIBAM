﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class PromptCopy
    {
        public string DescricaoCopy {  get; set; }
        public Briefing briefing { get; set; }
        public PublicoAlvo publicoAlvo { get; set; }
        public ControlesCopy controlesCopy { get; set; }
    }
}
