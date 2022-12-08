using System.Collections.Generic;
using Final.Game.Casting;
using Final.Game.Services;


namespace Final.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Tree tree = (Tree)cast.GetFirstActor("tree");
            Actor squirral = (Actor)cast.GetActors("squirral")[0];
            Actor squirral = (Actor)cast.GetActors("squirral")[1];
            Actor squirral = (Actor)cast.GetActors("squirral")[2];
            // List<Actor> segments = snake.GetSegments();
            Actor score = cast.GetFirstActor("score");
            // Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(squirral[0]);
            _videoService.DrawActors(squirral[1]);
            _videoService.DrawActors(squirral[2]);
            _videoService.DrawActor(score);
            _videoService.DrawActor(tree);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}