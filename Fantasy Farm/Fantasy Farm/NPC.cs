using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fantasy_Farm
{
    enum NPCState
    {
        Idle,
        Walk
    }
    enum Direction
    {
        North,
        South,
        East,
        West
    }

    class NPC : SpriteSheet
    {
        public int gridX = 0;
        public int gridY = 0;
        public bool dead = false;

        protected Rectangle[] animWalkN = { };
        protected Rectangle[] animWalkE = { };
        protected Rectangle[] animWalkW = { };
        protected Rectangle[] animWalkS = { };
        protected Rectangle[] animIdleN = { };
        protected Rectangle[] animIdleE = { };
        protected Rectangle[] animIdleW = { };
        protected Rectangle[] animIdleS = { };

        Vector2 target = Vector2.Zero;
        NPCState npcState = NPCState.Idle;
        Direction direction = Direction.South;

        public NPC(Texture2D texture)
            : base(texture)
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            if (npcState == NPCState.Walk)
            {
                if (position.X < target.X) position.X += 10;
                if (position.X > target.X) position.X -= 10;
                if (position.Y < target.Y) position.Y += 10;
                if (position.Y > target.Y) position.Y -= 10;

                if (position == target) npcState = NPCState.Idle;
            }
            UpdateAnim(gameTime);
        }
        public override void UpdateAnim(GameTime gameTime)
        {
            if (npcState == NPCState.Walk)
            {
                if (direction == Direction.North) animFrames = animWalkN;
                if (direction == Direction.South) animFrames = animWalkS;
                if (direction == Direction.East) animFrames = animWalkE;
                if (direction == Direction.West) animFrames = animWalkW;
            }
            if (npcState == NPCState.Idle)
            {
                if (direction == Direction.North) animFrames = animIdleN;
                if (direction == Direction.South) animFrames = animIdleS;
                if (direction == Direction.East) animFrames = animIdleE;
                if (direction == Direction.West) animFrames = animIdleW;
            }

            base.UpdateAnim(gameTime);
        }

        public void UpdateTarget()
        {
            target = new Vector2(gridX, gridY) * 120;
        }
        public void Move(GSPlay play, Direction moveDir)
        {
            if (npcState != NPCState.Idle) return;
            direction = moveDir;

            //check for collision

            if (moveDir == Direction.North && !play.CheckCollide(gridX, gridY - 1)) gridY--;
            if (moveDir == Direction.South && !play.CheckCollide(gridX, gridY + 1)) gridY++;
            if (moveDir == Direction.East && !play.CheckCollide(gridX + 1, gridY)) gridX++;
            if (moveDir == Direction.West && !play.CheckCollide(gridX - 1, gridY)) gridX--;

            npcState = NPCState.Walk;
            UpdateTarget(); // <- do this
        }
        public void Teleport(int x, int y)
        {
            gridX = x;
            gridY = y;
            UpdateTarget();
            position = target;

        }

    }
}
