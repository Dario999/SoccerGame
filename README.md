#SoccerGame
Projected by: Dario Ivanovski 171198, Tomi Pandaziev 151192, Nikola Edrovski 171299
1.	Објаснување на проблемот
 
На почетната форма имаме 3 опции едната е How to Play каде што се прикажуваат инструкции и контроли за играње, потоа имаме Play каде што започнува играта и Quit што доколку се кликне се прикажува диалог за потврда. 
 

Самото име на играта ни покажува дека станува збор за играње на фудбал во оваа игра меѓу два играча кои се претставени во вид на правоаголник кои се поставени пред головите и целта на играта е да се одбрани голот. 
 
Играчите имаат можност да се поместуваат нагоре и надолу со цел да го одбиат топчето на другата половина. Играчот 1 ги користи копчињата Up за движење нагоре и Down за движење надолу, додека пак играчот 2 ги користи копчињата NumPad8 за придвижување нагоре и NumPad2 за придвижување надолу. Доколку некој од играчите постигне гол во горниот дел на играта се изменува резултатот и се запишува поен на оној кој постигнал гол. Играта трае 60 секунди и на крај се прикажува кој е победникот.
  


2.	Во решението на проблемот се формирани две форми од една е почетната форма Main и главната форма PlayForm.Имаме класи Ball,Block и Player каде класата Ball претставува топчето кое се движи низ мапата,класата Block претставуваат пречките со кои се ограничени двата гола а класата Player се двајцата играчи.

3.	Со фукцијата 


private void timer1_Tick(object sender, EventArgs e)
{
if(Ball.Centar.Y  > Block11.Centar.Y && Ball.Centar.Y  < Block12.Centar.Y && Ball.Centar.X > 0 && Ball.Centar.X < 70)
{
                    int score = int.Parse(ply2lbl.Text);
                    int newScore = score + 1;
                    ply2lbl.Text = newScore.ToString();
                    flag = true;
                    Counter = 1;
                    timer1.Stop();
                    Ball = new Ball(new Point(480, 320), Color.White);
            }
            if (Ball.Centar.Y > Block21.Centar.Y && Ball.Centar.Y < Block22.Centar.Y && Ball.Centar.X > 900 && Ball.Centar.X < 920)
            {
                int score = int.Parse(ply1lbl.Text);
                int newScore = score + 1;
                ply1lbl.Text = newScore.ToString();
                flag = true;
                Counter = 1;
                timer1.Stop();
                Ball = new Ball(new Point(480, 320), Color.White);
            }
            Ball.isColided(Player1);
            Ball.isColided(Player2);
            Ball.Move(Left, Top, width, height, Player1, Player2);
            Invalidate();
}
   
топлата Ball се придвижува за 1 пожицина на секои 10 милисекунди.Кога топката ке влезе во голот на Player1 или на Player2 се додава поен во во Score лабелот.
