using Final.Game.Casting;
using Final.Game.Directing;
using Final.Game.Scripting;
using Final.Game.Services;


namespace Final
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Point start = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
            Point tree_start = new Point(0, Constants.MAX_Y);
            Color color = Constants.GREEN;

            // create the cast
            Cast cast = new Cast();
            cast.AddActor("squirral", new Actor(start, color));
            cast.AddActor("squirral", new Actor(start, color));
            cast.AddActor("squirral", new Actor(start, color));
            cast.AddActor("tree",     new Actor(tree_start, color));
            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}