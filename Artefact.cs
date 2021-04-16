using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    abstract class Artefact:IMagic
    {
      public abstract bool Reusable();//для возврата значения, с помощью которого будет определятся удаление или сохранение артефакта.
    }
}
//метод возобновляемый или нет, возвращает bool
