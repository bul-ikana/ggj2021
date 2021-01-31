/**
 *  This class contains all dialogue definitions. All dialogues
 * should be created and edited from here.
 */
public static class Dialogues
{
    public static Dialogue inicio;
    public static Dialogue after;
    public static Dialogue casa;

    static Dialogues()
    {
        Dialogues.inicio = new Dialogue();
        Dialogues.inicio.SetBackground("bg2");
        Dialogues.inicio.SetCharacter1("Julio");
        Dialogues.inicio.SetCharacter2("None");
        Dialogues.inicio.Add(0, "Bueno, aquí vamos de nuevo.");
        Dialogues.inicio.Add(0, "Hora de abrir la panadería, hoy cocinaré el mejor pan que este pueblo ha visto.");
        Dialogues.inicio.Add(0, "Hoy es. Hoy es el día.");


        Dialogues.after = new Dialogue();
        Dialogues.after.SetBackground("bg1");
        Dialogues.after.SetCharacter1("Julio");
        Dialogues.after.SetCharacter2("None");
        Dialogues.after.Add(0, "No se por qué sigo haciendo esto. Estoy cansado. No se en que momento la panadería se volvió una carga.");
        Dialogues.after.Add(0, "Antes disfrutaba mucho preparar el pan. Hornear. Los aromas y los sabores. Ahora solo me siento vacío al cocinar.");
        Dialogues.after.Add(0, "Mi pan ni siquiera se vende. No desde que Kruspy Crumbs llegó a Pastree. Soy un fracaso como panadero.");
        Dialogues.after.Add(0, "A veces me pregunto que diría la tía Pasty de todo esto. ¿Estaría orgullosa? No, nadie podría sentir orgullo de este fracaso.");
        Dialogues.after.Add(0, "Perdóname tía Pasty. Dejaste en mis manos la tradición panadera de la familia y lo único que logré fue este pan insipido y sin amor. Lo siento.");

        Dialogues.casa = new Dialogue();
        Dialogues.casa.SetBackground("bg1");
        Dialogues.casa.SetCharacter1("Julio");
        Dialogues.casa.SetCharacter2("Pasty");
        Dialogues.casa.Add(1, "Querido Julio.");
        Dialogues.casa.Add(0, "¿Qué es esto? ¿Una carta de la abuela Pasty?");
        Dialogues.casa.Add(1, "Por favor te pido leas hasta el final de esta carta porque es mi voluntad que sepas que lo siento y estoy totalmente arrepentida de alejarme de tí.");
        Dialogues.casa.Add(1, "Si estás leyendo esto es porque mi lucha contra mi enfermedad me ha rebasado y ahora he tomado otro camino.");
        Dialogues.casa.Add(1, "No me puedo ir sin decirte lo mucho que te quiero. Siempre fuiste la única persona auténtica en esta familia, perdóname por no entender.");
        Dialogues.casa.Add(1, "Tal vez no sea la persona más preparada, ni mucho menos estoy segura de entender ni de entenderte pero te escribo con el corazón y este nunca se equivoca.");
        Dialogues.casa.Add(0, "Abuela...");
        Dialogues.casa.Add(1, "Después de que nos alejamos las cosas con la familia no fueron bien, comenzaron a salir aquellas intenciones disfrazadas de buen trato, nada más que interés disfrazados.");
        Dialogues.casa.Add(1, "En cuanto me dí cuenta de esta farsa decidí cerrar la panadería de la familia y me deshice de todas mis recetas, pues no quería que cayeran en manos equivocadas.");
        Dialogues.casa.Add(1, "Ahora tienes en tus manos parte de mi recetario. Por ahora sólo contiene recetas básicas. El resto se encuentran en Pastree resguardadas por varios de mis verdaderos amigos.");
        Dialogues.casa.Add(1, "En tus manos dejo mi legado y el de nuestra familia. Solo tú puedes decidir si quieres encontrarlo o no.");
        Dialogues.casa.Add(1, "Recuerda quién eres.\n\nTe quiere mucho, tu tía abuela Pasty.");
    }
}
