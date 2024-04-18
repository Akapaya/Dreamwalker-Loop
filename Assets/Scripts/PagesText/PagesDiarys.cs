public class PagesDiarys
{
    private string[] messages;

    public string[] Messages { get => messages; }

    public PagesDiarys(Languages languages)
    {
        switch (languages)
        {
            case Languages.English:
                {
                    messages = new string[]
                        {
                            "How strange, I woke up in my bed exactly as I remembered before going to sleep. I remember putting that video playlist on, but something seems out of place...",
                            "It keeps happening: I wake up in bed, get up and walk around the house. I realize I'm still in the dream, so I close my eyes and wake up in my bed again. This cycle repeats itself, and repeats itself... I don't know how many times this has happened.",
                            "I'm starting to despair. I know I'm dreaming and I try hard to wake up, but I can't. I always go back to the same place. I'm very afraid of being in a coma. I imagine it's like this: I try to wake up, but my body doesn't respond. And then my brain makes me dream again, as if I were at home. The fear is overwhelming�",
                            "I decided to explore the house more carefully. Each room looks the same as in the real world, but there are small differences. The painting in the living room depicts a landscape I have never seen before. The kitchen has a strange smell, a mix of mold and something metallic. And the bedroom... the bedroom is where everything begins and ends.\r\n\r\nI try to remember how I got here. I look through drawers, look under the bed, but I can't find anything that makes sense. The laptop is still playing the playlist, as if it's stuck in a loop too. The songs echo through the halls, distorted and haunting.",
                            "Maybe there is a way out. Maybe I need to find an answer within this twisted house. But fear paralyzes me. Every time I close my eyes, I fear I won't wake up again. And so, I continue in this cycle, searching for a truth that seems unattainable.",
                        };
                    break;
                }

            case Languages.Portuguese:
                {
                    messages = new string[]
                        {
                            "Que estranho, acordei na minha cama exatamente como me lembrava antes de dormir. Lembro-me de ter colocado aquela playlist de v�deos para tocar, mas algo parece fora do lugar�",
                            "Continua acontecendo: eu acordo na cama, levanto e vou andar pela casa. Percebo que ainda estou dentro do sonho, ent�o fecho meus olhos e acordo novamente na minha cama. Esse ciclo se repete, e se repete� N�o sei mais quantas vezes isso j� aconteceu.",
                            "Estou come�ando a entrar em desespero. Sei que estou sonhando e me esfor�o para acordar, mas n�o consigo. Volto sempre para o mesmo lugar. Tenho muito medo de estar em coma. Imagino que seja assim: tento acordar, mas meu corpo n�o responde. E ent�o meu c�rebro me faz voltar a sonhar, como se eu estivesse em casa. O medo � avassalador�",
                            "Decidi explorar a casa com mais aten��o. Cada c�modo parece igual ao mundo real, mas h� pequenas diferen�as. O quadro na sala de estar retrata uma paisagem que nunca vi antes. A cozinha tem um cheiro estranho, uma mistura de mofo e algo met�lico. E o quarto� o quarto � onde tudo come�a e termina.\r\n\r\nTento lembrar de como cheguei aqui. Reviro gavetas, olho debaixo da cama, mas n�o encontro nada que fa�a sentido. O laptop ainda est� tocando a playlist, como se estivesse preso em um loop tamb�m. As m�sicas ecoam pelos corredores, distorcidas e assustadoras.",
                            "Talvez haja uma sa�da. Talvez eu precise encontrar uma resposta dentro desta casa distorcida. Mas o medo me paralisa. Cada vez que fecho os olhos, temo que n�o vou acordar novamente. E assim, continuo nesse ciclo, buscando uma verdade que parece inalcan��vel.",
                        };
                    break;
                }
        }
    }
}

public enum Languages
{
    None,
    Portuguese,
    English
}