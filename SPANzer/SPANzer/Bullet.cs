﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SPANzer
{
	public class Bullet
	{
		private float hitBoxRadius = 20f;
		private const int bulletNumber = 5;
		public Queue<Ball> Bullets;
		public int i = 0;
		public Bullet()
		{
			Bullets = new Queue<Ball>(bulletNumber);
		}
		
		public void Expire()
		{
			if (Bullets.Any()) {
				Ball current = Bullets.Peek();
				if (DateTime.Now - current.created >= current.lifeTime)
				{
					Bullets.Dequeue();
				}
			}
		}
		
		public void Add(PointF start, float vX, float vY)
		{
			if(Bullets.Count < bulletNumber)
			{
				Bullets.Enqueue(new Ball(start,vX,vY));
			}
		}
		
		public void RemoveBullets()
		{
			while(Bullets.Any())
			{
				Bullets.Dequeue();
			}
		}

		public void MoveBullets()
		{
			foreach (Ball b in Bullets)
			{
				CollisionWithWalls(b);
				CollisionWithTank(b);
				b.center.X += b.vX;
				b.center.Y += b.vY;
			}
				
		}

		public void DrawBullet(Graphics g)
		{
			foreach (Ball b in Bullets)
			{
				b.Draw(g);
			}
		}

		public void CollisionWithWalls(Ball b)
		{
			foreach (Brick w in GameWindow.wall.allWalls)
			{
				if (w.vertical == false) //horizontal
				{
					if (b.center.X >= w.wallStart.X && b.center.X <= w.wallEnd.X)
					{
						//collision with the wall above
						if (b.center.Y >= w.wallStart.Y && b.center.Y + b.vY <= w.wallStart.Y)
						{
							b.vY = -b.vY;
						}
						//collision with the wall below
						if (b.center.Y <= w.wallStart.Y && b.center.Y + b.vY >= w.wallStart.Y)
						{
							b.vY = -b.vY;
						}
					}
					//checks if bullet can collide with the walls end
					if (b.center.Y <= w.wallStart.Y && b.center.Y >= w.wallStart.Y)
					{
						//collision with the right end
						if (b.center.X >= w.wallEnd.X && b.center.X + b.vX <= w.wallEnd.X)
						{
							b.vX = -b.vX;
						}
						//collision with the left end
						if (b.center.X <= w.wallStart.X && b.center.X + b.vX >= w.wallStart.X)
						{
							b.vX = -b.vX;
						}
					}
				}
				else if (w.vertical == true) //vertical
				{
					//check if bullet can collide with wall's side
					if (b.center.Y >= w.wallStart.Y && b.center.Y <= w.wallEnd.Y)
					{
						//collision with the wall from right
						if (b.center.X >= w.wallStart.X && b.center.X + b.vX <= w.wallStart.X)
						{
							b.vX = -b.vX;
						}
						//collision with the wall from left
						if (b.center.X <= w.wallStart.X && b.center.X + b.vX >= w.wallStart.X)
						{
							b.vX = -b.vX;
						}
					}
					//checks if bullet can collide with the walls end
					if (b.center.X <= w.wallStart.X && b.center.X >= w.wallStart.X)
					{
						//collision with the bottom end
						if (b.center.Y >= w.wallEnd.Y && b.center.Y + b.vY <= w.wallEnd.Y)
						{
						b.vY = -b.vY;
						}
						//collision with top end
						if (b.center.Y <= w.wallStart.Y && b.center.Y + b.vY >= w.wallStart.Y)
						{
							b.vY = -b.vY;
						}
					}
				}
			}
		}

		public void CollisionWithTank(Ball b)
		{
			//Tank1
			if(b.center.Y >= GameWindow.t1.center.Y - hitBoxRadius && b.center.Y <= GameWindow.t1.center.Y + hitBoxRadius)
			{
				//from left
				if (b.center.X <= GameWindow.t1.center.X - hitBoxRadius && b.center.X + b.vX >= GameWindow.t1.center.X - hitBoxRadius)
				{
					GameWindow.t1.hit = true;
				}
				//from right
				if(b.center.X >= GameWindow.t1.center.X + hitBoxRadius && b.center.X +b.vX <=GameWindow.t1.center.X + hitBoxRadius)
				{
					GameWindow.t1.hit = true;
				}
			}
			if (b.center.X >= GameWindow.t1.center.X - hitBoxRadius && b.center.X <= GameWindow.t1.center.X + hitBoxRadius)
			{
				//from above
				if (b.center.Y <= GameWindow.t1.center.Y - hitBoxRadius && b.center.Y + b.vY >= GameWindow.t1.center.Y - hitBoxRadius)
				{
					GameWindow.t1.hit = true;
				}
				//from below
				if (b.center.Y >= GameWindow.t1.center.Y + hitBoxRadius && b.center.Y + b.vY <= GameWindow.t1.center.Y + hitBoxRadius)
				{
					GameWindow.t1.hit = true;
				}
			}
			//Tank2
			if (b.center.Y >= GameWindow.t2.center.Y - hitBoxRadius && b.center.Y <= GameWindow.t2.center.Y + hitBoxRadius)
			{
				//from left
				if (b.center.X <= GameWindow.t2.center.X - hitBoxRadius && b.center.X + b.vX >= GameWindow.t2.center.X - hitBoxRadius)
				{
					GameWindow.t2.hit = true;
				}
				//from right
				if (b.center.X >= GameWindow.t2.center.X + hitBoxRadius && b.center.X + b.vX <= GameWindow.t2.center.X + hitBoxRadius)
				{
					GameWindow.t2.hit = true;
				}
			}
			if (b.center.X >= GameWindow.t2.center.X - hitBoxRadius && b.center.X <= GameWindow.t2.center.X + hitBoxRadius)
			{
				//from above
				if (b.center.Y <= GameWindow.t2.center.Y - hitBoxRadius && b.center.Y + b.vY >= GameWindow.t2.center.Y - hitBoxRadius)
				{
					GameWindow.t2.hit = true;
				}
				//from below
				if (b.center.Y >= GameWindow.t2.center.Y + hitBoxRadius && b.center.Y + b.vY <= GameWindow.t2.center.Y + hitBoxRadius)
				{
					GameWindow.t2.hit = true;
				}
			}
		}
	}
}
 