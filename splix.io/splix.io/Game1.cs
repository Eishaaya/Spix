using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace splix.io
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        int playerchose2 = 0;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Random random;
        Texture2D bladeimage;
        Texture2D heliimage;
        TimeSpan untilmusend = new TimeSpan(0, 0, 2, 46);
        TimeSpan waittillmusend;
        TimeSpan untilbox = new TimeSpan(0, 0, 0, 0, 30);
        TimeSpan waitbox;
        TimeSpan untilus = new TimeSpan(0, 0, 0, 0, 45);
        TimeSpan waitus;
        TimeSpan untilhs = new TimeSpan(0, 0, 0, 32, 0);
        TimeSpan waiths = new TimeSpan(0, 0, 0, 32, 0);
        TimeSpan untilmss = new TimeSpan(0, 0, 0, 11, 0);
        TimeSpan waitmss = new TimeSpan(0, 0, 0, 11, 0);
        TimeSpan untilbn = new TimeSpan(0, 0, 0, 32, 0);
        TimeSpan waitbn = new TimeSpan(0, 0, 0, 32, 0);
        TimeSpan untiltn = new TimeSpan(0, 0, 2, 11, 0);
        TimeSpan waittn = new TimeSpan(0, 0, 2, 11, 0);
        TimeSpan untilts = new TimeSpan(0, 0, 1, 46, 0);
        TimeSpan waitts = new TimeSpan(0, 0, 1, 46, 0);
        int playerchose;
        Player otherplayer;
        Sprite stanbutt;
        Sprite killbutt;
        Sprite soldierbutt;
        Sprite regbutt;
        Sprite trapbutt;
        Sprite huntbutt;
        Sprite movebutt;
        Sprite wizbutt;
        Sprite rules;
        Sprite health;
        Sprite death;
        Sprite title;
        Sprite backimage;
        Sprite kingbutt;
        cameras_are_boring SamTheCam;
        List<Texture2D> pi;
        Random pis = new Random();
        List<Sprite> dooms;
        Sprite ninjabutt;
        Sprite phantombutt;
        List<Texture2D> playerImages;
        List<Player> players;
        List<int> speeds;
        Random playerrand = new Random();
        Song backmusic;
        Grid grid;
        Vector2 gridSize;
        List<int> ph;
        List<float> pa;
        public List<SoundEffect> phs;
        KeyboardState prevKs;
        KeyboardState ks;
        List<Texture2D> evils;
        List<float> evilelife;
        List<float> evilattack;
        List<pawns> baddies;
        bool menu = true;
        int count = 0;
        int evil;
        List<Texture2D> goods;
        List<float> goodlife;
        List<float> goodattack;
        List<pawns> goodies;
        int good;
        SoundEffect hs;
        SoundEffect mss;
        SoundEffect bn;
        SoundEffect tn;
        SoundEffect ts;
        SoundEffectInstance tninstance;
        SoundEffectInstance tsinstance;
        SoundEffectInstance msinstance;
        SoundEffectInstance hsinstance;
        SoundEffectInstance bninstance;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            Window.Title = "Spixio";
            base.Initialize();
        }
        protected override void LoadContent()
        {
            bladeimage = (Content.Load<Texture2D>("rotor"));
            heliimage = (Content.Load<Texture2D>("heli"));
            random = new Random();
            #region army spawning
            evil = 6;
            dooms = new List<Sprite>();
            evils = new List<Texture2D>();
            goodies = new List<pawns>();
            baddies = new List<pawns>();
            goods = new List<Texture2D>();
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("heli"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("jeep"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("am"));
            goods.Add(Content.Load<Texture2D>("tank2"));
            goods.Add(Content.Load<Texture2D>("heli"));
            goods.Add(Content.Load<Texture2D>("zepplin"));
            goods.Add(Content.Load<Texture2D>("mech"));
            evils.Add(Content.Load<Texture2D>("isis"));
            evils.Add(Content.Load<Texture2D>("isis"));
            evils.Add(Content.Load<Texture2D>("isis"));
            evils.Add(Content.Load<Texture2D>("isis"));
            evils.Add(Content.Load<Texture2D>("isis"));
            evils.Add(Content.Load<Texture2D>("truck"));
            evils.Add(Content.Load<Texture2D>("tank"));
            evils.Add(Content.Load<Texture2D>("truck"));
            goodattack = new List<float>();
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(20);
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(3);
            goodattack.Add(3);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(2);
            goodattack.Add(17.5f);
            goodattack.Add(20);
            goodattack.Add(25);
            goodattack.Add(35);
            goodlife = new List<float>();
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(275);
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(90);
            goodlife.Add(90);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(20);
            goodlife.Add(175);
            goodlife.Add(275);
            goodlife.Add(500);
            goodlife.Add(350);
            evilattack = new List<float>();
            evilattack.Add(2);
            evilattack.Add(2);
            evilattack.Add(2);
            evilattack.Add(2);
            evilattack.Add(2);
            evilattack.Add(3);
            evilattack.Add(3);
            evilattack.Add(15.5f);
            evilelife = new List<float>();
            evilelife.Add(15);
            evilelife.Add(15);
            evilelife.Add(15);
            evilelife.Add(15);
            evilelife.Add(15);
            evilelife.Add(75);
            evilelife.Add(75);
            evilelife.Add(150);
            #endregion
            ph = new List<int>();
            pa = new List<float>();
            playerImages = new List<Texture2D>();
            playerImages.Add(Content.Load<Texture2D>("killer"));
            playerImages.Add(Content.Load<Texture2D>("mover"));
            playerImages.Add(Content.Load<Texture2D>("circle"));
            playerImages.Add(Content.Load<Texture2D>("stanmode"));
            playerImages.Add(Content.Load<Texture2D>("soldier"));
            playerImages.Add(Content.Load<Texture2D>("trapper"));
            playerImages.Add(Content.Load<Texture2D>("hunter"));
            playerImages.Add(Content.Load<Texture2D>("wiz"));
            playerImages.Add(Content.Load<Texture2D>("ninja"));
            playerImages.Add(Content.Load<Texture2D>("phantom"));
            playerImages.Add(Content.Load<Texture2D>("king"));
            speeds = new List<int>();
            speeds.Add(2);
            speeds.Add(30);
            speeds.Add(15);
            speeds.Add(3);
            speeds.Add(6);
            speeds.Add(5);
            speeds.Add(5);
            speeds.Add(5);
            speeds.Add(3);
            speeds.Add(10);
            speeds.Add(2);
            #region pawnloadingstuff
            pi = new List<Texture2D>();
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("br"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("c"));
            pi.Add(Content.Load<Texture2D>("c"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("sn"));
            pi.Add(Content.Load<Texture2D>("mn"));
            pi.Add(Content.Load<Texture2D>("spn"));
            pi.Add(Content.Load<Texture2D>("br"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("v"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("a"));
            pi.Add(Content.Load<Texture2D>("c"));
            pi.Add(Content.Load<Texture2D>("c"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("ar"));
            pi.Add(Content.Load<Texture2D>("d"));
            pi.Add(Content.Load<Texture2D>("r"));
            pi.Add(Content.Load<Texture2D>("r"));
            pi.Add(Content.Load<Texture2D>("r"));
            pi.Add(Content.Load<Texture2D>("r"));
            pi.Add(Content.Load<Texture2D>("m"));
            pi.Add(Content.Load<Texture2D>("m"));
            pi.Add(Content.Load<Texture2D>("m"));
            pi.Add(Content.Load<Texture2D>("m"));
            pi.Add(Content.Load<Texture2D>("m"));
            pi.Add(Content.Load<Texture2D>("ms"));
            pi.Add(Content.Load<Texture2D>("ms"));
            pi.Add(Content.Load<Texture2D>("ms"));
            pi.Add(Content.Load<Texture2D>("ms"));
            pi.Add(Content.Load<Texture2D>("ms"));
            pi.Add(Content.Load<Texture2D>("d"));
            pi.Add(Content.Load<Texture2D>("s"));
            pi.Add(Content.Load<Texture2D>("g"));
            pi.Add(Content.Load<Texture2D>("g"));
            pi.Add(Content.Load<Texture2D>("g"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("t"));
            pi.Add(Content.Load<Texture2D>("ca"));
            pi.Add(Content.Load<Texture2D>("ca"));
            pi.Add(Content.Load<Texture2D>("ca"));
            pi.Add(Content.Load<Texture2D>("ca"));
            pi.Add(Content.Load<Texture2D>("tnt"));
            pi.Add(Content.Load<Texture2D>("tnt"));
            pi.Add(Content.Load<Texture2D>("tnt"));
            pi.Add(Content.Load<Texture2D>("tnt"));
            pi.Add(Content.Load<Texture2D>("tnt"));
            pi.Add(Content.Load<Texture2D>("sw"));
            pi.Add(Content.Load<Texture2D>("sw"));
            pi.Add(Content.Load<Texture2D>("sw"));
            pi.Add(Content.Load<Texture2D>("sw"));
            pi.Add(Content.Load<Texture2D>("sw"));
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(75);
            ph.Add(50);
            ph.Add(105);
            ph.Add(225);
            ph.Add(20);
            ph.Add(20);
            ph.Add(20);
            ph.Add(15);
            ph.Add(15);
            ph.Add(15);
            ph.Add(150);
            ph.Add(150);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(45);
            ph.Add(30);
            ph.Add(75);
            ph.Add(225);
            ph.Add(20);
            ph.Add(20);
            ph.Add(20);
            ph.Add(15);
            ph.Add(15);
            ph.Add(15);
            ph.Add(120);
            ph.Add(120);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(500);
            ph.Add(150);
            ph.Add(150);
            ph.Add(150);
            ph.Add(150);
            ph.Add(75);
            ph.Add(75);
            ph.Add(75);
            ph.Add(75);
            ph.Add(75);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(30);
            ph.Add(500);
            ph.Add(1500);
            ph.Add(750);
            ph.Add(750);
            ph.Add(750);
            ph.Add(250);
            ph.Add(250);
            ph.Add(250);
            ph.Add(250);
            ph.Add(250);
            ph.Add(250);
            ph.Add(100);
            ph.Add(100);
            ph.Add(100);
            ph.Add(100);
            ph.Add(60);
            ph.Add(60);
            ph.Add(60);
            ph.Add(60);
            ph.Add(60);
            ph.Add(1);
            ph.Add(1);
            ph.Add(1);
            ph.Add(1);
            ph.Add(1);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(3);
            pa.Add(.25f);
            pa.Add(.25f);
            pa.Add(.25f);
            pa.Add(2.5f);
            pa.Add(2.5f);
            pa.Add(2.5f);
            pa.Add(1);
            pa.Add(1);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(1);
            pa.Add(2);
            pa.Add(.5f);
            pa.Add(3);
            pa.Add(.25f);
            pa.Add(.25f);
            pa.Add(.25f);
            pa.Add(2.5f);
            pa.Add(2.5f);
            pa.Add(2.5f);
            pa.Add(1);
            pa.Add(1);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(7.5f);
            pa.Add(1);
            pa.Add(1);
            pa.Add(1);
            pa.Add(1);
            pa.Add(2);
            pa.Add(2);
            pa.Add(2);
            pa.Add(2);
            pa.Add(2);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(3.5f);
            pa.Add(7.5f);
            pa.Add(15);
            pa.Add(5);
            pa.Add(5);
            pa.Add(5);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(.75f);
            pa.Add(5);
            pa.Add(5);
            pa.Add(5);
            pa.Add(5);
            pa.Add(300);
            pa.Add(300);
            pa.Add(300);
            pa.Add(300);
            pa.Add(300);
            pa.Add(.6f);
            pa.Add(.6f);
            pa.Add(.6f);
            pa.Add(.6f);
            pa.Add(.6f);
            phs = new List<SoundEffect>();
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ds"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("ds"));
            phs.Add(Content.Load<SoundEffect>("ds"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("ks"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            phs.Add(Content.Load<SoundEffect>("brsound"));
            #endregion
            backmusic = Content.Load<Song>("music for game");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hs = Content.Load<SoundEffect>("heli sound");
            hsinstance = hs.CreateInstance();
            mss = Content.Load<SoundEffect>("marching sound");
            msinstance = mss.CreateInstance();
            bn = Content.Load<SoundEffect>("blimp sound");
            bninstance = bn.CreateInstance();
            tn = Content.Load<SoundEffect>("tank sound");
            tninstance = tn.CreateInstance();
            ts = Content.Load<SoundEffect>("truck sound");
            tsinstance = ts.CreateInstance();
            gridSize = new Vector2(9000, 4500);
            grid = new Grid((int)gridSize.X / 30, (int)gridSize.Y / 30, Content.Load<Texture2D>("CellBlock"));
            Texture2D playerImage = playerImages[0];
            backimage = new Sprite(Content.Load<Texture2D>("sand"), new Vector2(3300, 1600), Color.White);
            killbutt = new Sprite(Content.Load<Texture2D>("killbutt"), new Vector2(200, 500), Color.White);
            rules = new Sprite(Content.Load<Texture2D>("rules"), new Vector2(960, 800), Color.White);
            title = new Sprite(Content.Load<Texture2D>("title"), new Vector2(960, 200), Color.White);
            wizbutt = new Sprite(Content.Load<Texture2D>("wizbutt"), new Vector2(500, 800), Color.White);
            movebutt = new Sprite(Content.Load<Texture2D>("movebutt"), new Vector2(500, 500), Color.White);
            stanbutt = new Sprite(Content.Load<Texture2D>("stanbutt"), new Vector2(800, 500), Color.White);
            trapbutt = new Sprite(Content.Load<Texture2D>("trapper butt"), new Vector2(1700, 500), Color.White);
            regbutt = new Sprite(Content.Load<Texture2D>("circlebutt"), new Vector2(1100, 500), Color.White);
            phantombutt = new Sprite(Content.Load<Texture2D>("phantombutt"), new Vector2(1700, 800), Color.White);
            ninjabutt = new Sprite(Content.Load<Texture2D>("ninjabutt"), new Vector2(1400, 800), Color.White);
            kingbutt = new Sprite(Content.Load<Texture2D>("kingbutt"), new Vector2(250, 200), Color.White);
            soldierbutt = new Sprite(Content.Load<Texture2D>("soldierbutt"), new Vector2(1400, 500), Color.White);
            huntbutt = new Sprite(Content.Load<Texture2D>("huntbutt"), new Vector2(200, 800), Color.White);
            player = new Player(playerImages[0], new Vector2((random.Next(0, (int)gridSize.X / 30) * 30) + 15, (random.Next(0, (int)gridSize.Y / 30) * 30) + 15), speeds[0], Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"), Player.playerType.human);
            player.shootkey = Keys.Space;
            player.Rightkey = Keys.Right;
            player.Leftkey = Keys.Left;
            player.Downkey = Keys.Down;
            player.UpKey = Keys.Up;
            otherplayer = new Player(playerImages[0], new Vector2((random.Next(0, 64) * 30) + 15, (random.Next(0, 36) * 30) + 15), 1, Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"), Player.playerType.human);
            otherplayer.UpKey = Keys.W;
            otherplayer.Downkey = Keys.S;
            otherplayer.Leftkey = Keys.A;
            otherplayer.Rightkey = Keys.D;
            otherplayer.shootkey = Keys.Tab;
            players = new List<Player>();
            players.Add(player);
            players.Add(otherplayer);
            health = new Sprite(Content.Load<Texture2D>("health"), new Vector2(850, 30), players[count].colors[players[count].colorselect]);
            death = new Sprite(Content.Load<Texture2D>("death"), new Vector2(850, 30), players[count].colors[players[count].colorselect]);
            MediaPlayer.Play(backmusic);
            health.Scale = new Vector2(1, 1);
            for (int i = 0; i < players.Count; i++)
            {
                players[i].arrow = Content.Load<Texture2D>("arrow");
                players[i].arrowimage = Content.Load<Texture2D>("ar");
                players[i].gunimage = Content.Load<Texture2D>("ms");
                players[i].bulletimage = Content.Load<Texture2D>("b");
                players[i].ballimage = Content.Load<Texture2D>("cb");
                players[i].cannonimage = Content.Load<Texture2D>("ca");
            }
            backimage.Scale = new Vector2(6.75f, 6.75f);
            SamTheCam = new cameras_are_boring(players[0]);
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            waitbn += gameTime.ElapsedGameTime;
            if (!menu && untilbn < waitbn)
            {
                bninstance.Volume = 0.36f;
                bninstance.Play();
                waitbn = TimeSpan.Zero;
            }
            waittn += gameTime.ElapsedGameTime;
            if (!menu && untiltn < waittn)
            {
                tninstance.Volume = 0.30f;
                tninstance.Play();             
                waittn = TimeSpan.Zero;                
            }
            waitts += gameTime.ElapsedGameTime;
            if (!menu && untilts < waitts)
            {
               tsinstance.Volume = 0.30f;             
               tsinstance.Play();
               waitts = TimeSpan.Zero;
            }
            waiths += gameTime.ElapsedGameTime;
            if (!menu && untilhs < waiths)
            {
                hsinstance.Volume = 0.72f;
                hsinstance.Play();
                waiths = TimeSpan.Zero;
            }
            waitmss += gameTime.ElapsedGameTime;
            if (!menu && untilmss < waitmss)
            {
                msinstance.Volume = 0.72f;
                msinstance.Play();
                waitmss = TimeSpan.Zero;
            }
            waitbox += gameTime.ElapsedGameTime;
            if (waitbox >= untilbox)
            {
                evil = random.Next(0, 8);
                baddies.Add(new pawns(evils[evil], new Vector2(random.Next(0, 45)*30,
                    random.Next(0, 170)*30), Color.White, 3, evilelife[evil], evilattack[evil], 
                    Content.Load < SoundEffect>("brsound"), new TimeSpan(0, 0, 0, 0, 200)));
                waitbox = TimeSpan.Zero;
            }
            for (int i = 0; i < goodies.Count; i++)
            {
                goodies[i].update(gameTime);
            }
            waitus += gameTime.ElapsedGameTime;
            if(waitus >= untilus)
            {
                goodies.Add(new pawns(goods[good], new Vector2(random.Next(270, 315) * 30, random.Next(0, 170) * 30), Color.White, 3, goodlife[good], goodattack[good], Content.Load<SoundEffect>("brsound"), new TimeSpan(0, 0, 0, 0, 175)));
                goodies[goodies.Count - 1].heli = heliimage;
                if (goodies[goodies.Count - 1].heli == goodies[goodies.Count - 1].Image)
                {
                    goodies[goodies.Count - 1].blade = bladeimage;
                    goodies[goodies.Count - 1].rotor = new Sprite(goodies[goodies.Count - 1].blade, new Vector2(0, 0), Color.White);

                }
                waitus = TimeSpan.Zero;
                good = random.Next(0, 52);
            }
            for (int i = 0; i < baddies.Count; i++)
            {
                baddies[i].update(gameTime);
            }

            waittillmusend += gameTime.ElapsedGameTime;
            if (waittillmusend >= untilmusend)
            {
                MediaPlayer.Play(backmusic);
                waittillmusend = TimeSpan.Zero;
            }
            prevKs = ks;
            ks = Keyboard.GetState();
            if (menu)
            {

                if (ks.IsKeyDown(Keys.NumPad1))
                {
                    players[count].number = 0;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad2))
                {
                    players[count].number = 1;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad3))
                {
                    players[count].number = 3;
                    players[count].lives = 3;

                }
                if (ks.IsKeyDown(Keys.NumPad4))
                {
                    players[count].number = 2;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad5))
                {
                    players[count].number = 4;
                    players[count].lives = 3;

                }
                if (ks.IsKeyDown(Keys.NumPad6))
                {
                    players[count].number = 5;
                    players[count].isboom = true;
                    players[count].lives = 2;
                }
                if (ks.IsKeyDown(Keys.NumPad7))
                {
                    players[count].number = 6;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad8))
                {
                    players[count].number = 7;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad9))
                {
                    players[count].number = 8;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad0))
                {
                    players[count].number = 9;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.Multiply))
                {
                    players[count].number = 10;
                    players[count].lives = 1;
                    players[count].ispawner = true;
                }
                if (ks.IsKeyDown(Keys.Enter) && prevKs.IsKeyUp(Keys.Enter))
                {
                    if (players[count].number == -1)
                    {
                        players[count].number = playerrand.Next(0, 11);
                        players[count].lives = 1;
                    }
                    if (players[count].number == 10)
                    {
                        players[count].ispawner = true;
                    }
                    if (players[count].number == 5)
                    {
                        players[count].isboom = true;
                        players[count].lives = 2;
                        players[count].boomimage = Content.Load<Texture2D>("trap");
                        players[count].boomspeed = 0;
                    }
                    if (players[count].number == 8)
                    {
                        players[count].isboom = true;
                        players[count].lives = 1;
                        players[count].boomimage = Content.Load<Texture2D>("sh");
                        players[count].boomspeed = 35;
                    }
                    if (players[count].number == 6)
                    {
                        players[count].isboom = true;
                        players[count].boomimage = Content.Load<Texture2D>("ammo");
                        players[count].boomspeed = 60;
                    }
                    if (players[count].number == 7)
                    {
                        players[count].isboom = true;
                        players[count].boomimage = Content.Load<Texture2D>("fire");
                        players[count].lives = 3;
                        players[count].boomspeed = 30;
                    }
                    if (players[count].number == 4)
                    {
                        players[count].lives = 3;
                    }
                    if (players[count].number == 3)
                    {
                        players[count].lives = 3;
                    }
                    playerchose = players[count].number;
                    players[count].Image = playerImages[playerchose];
                    players[count].speed = speeds[playerchose];
                    count++;
                    if (count >= 2)
                    {
                        menu = false;
                    }
                }
                #region Blah
                //if (menuleft == 1)
                //{
                //    if (ks.IsKeyDown(Keys.NumPad1))
                //    {
                //        number2 = 0;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad2))
                //    {
                //        number2 = 1;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad3))
                //    {
                //        number2 = 3;
                //        otherplayer.lives = 3;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad4))
                //    {
                //        number2 = 2;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad5))
                //    {
                //        number2 = 4;
                //        otherplayer.lives = 3;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad6))
                //    {
                //        number2 = 5;
                //        isboom2 = true;
                //        otherplayer.lives = 2;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad7))
                //    {
                //        number2 = 6;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad8))
                //    {
                //        number2 = 7;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad9))
                //    {
                //        number2 = 8;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad0))
                //    {
                //        number2 = 9;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.Enter))
                //    {
                //        if (number2 == -1)
                //        {
                //            number2 = playerrand.Next(0, 10);
                //            otherplayer.lives = 1;
                //        }
                //        if (number2 == 5)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 2;
                //        }
                //        if (number2 == 8)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 1;
                //        }
                //        if (number2 == 6)
                //        {
                //            isboom2 = true;
                //        }
                //        if (number2 == 7)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 3;
                //        }
                //        if (number2 == 4)
                //        {
                //            otherplayer.lives = 3;
                //        }
                //        if (number2 == 3)
                //        {
                //            otherplayer.lives = 3;
                //        }
                //        otherplayer.Image = players[number2];
                //        otherplayer.speed = speeds[number2];
                //        startlife2 = otherplayer.lives;
                //        menuleft--;
                //        if (menuleft <= 0)
                //        {
                //            menu = false;
                //        }
                //    }
                #endregion
            }
            else
            {
                bool somethingHit = false;

                //start of cleanup.
                for (int p = 0; p < players.Count; p++)
                {
                    if (players[p].LocationX <= 0 || players[p].LocationX >= gridSize.X || players[p].LocationY <= 0 || players[p].LocationY >= gridSize.Y)
                    {
                        players.RemoveAt(p);
                        break;
                    }

                    for (int op = 0; op < players.Count; op++)
                    {
                        if (players[p].IntersectsWithTrail(players[op]) && p != op)
                        {
                            /*if (players[i].lives == players[i].prevlives)
                            {
                                players[i].lives--;
                            }
                            
                            players[i].prevlives = players[i].lives;*/
                            if (players[p].Image != playerImages[0] && players[p].Image != playerImages[3])
                            {
                                somethingHit = true;

                                players[p].lives--;
                                if (players[p].lives <= 0)
                                {
                                    players[p].isdead = true;
                                    players.RemoveAt(p);
                                }
                            }
                            else
                            {
                                //if (players[i].Location == players[j])
                            }
                            break;
                        }
                        if (menu == false && players[p].isdead == false && players[op].isdead == false)
                        {
                            int blah = pis.Next(0, 112);
                            players[p].Update(gameTime, ks, prevKs, health, gameTime);
                            players[p].pawnimage = pi[blah];
                            players[p].pawnhealth = ph[blah];
                            players[p].pawnattack = pa[blah];
                            players[p].pawnhit = phs[blah];
                            for (int googoogaga = 0; googoogaga < players[p]._trail._tails.Count; googoogaga++)
                            {
                                if (players[op].IntersectsWithTerritory(players[p]._trail._tails[googoogaga].Hitbox) && p != op)
                                {
                                    if (players[p].IntersectsWithTrail(players[op]))
                                    {
                                        players[p].lives--;
                                    }
                                }
                            }//How can you miss me??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
                            if (players[op].pawns.Count > 0 && p != op)
                            {
                                for (int opp = 0; opp < players[op].pawns.Count; opp++)
                                {
                                    if (players[p].IntersectsWithTrail(players[op].pawns[opp]) && players[p].number != 0)
                                    {
                                        players[p].lives--;
                                    }
                                    for (int pp = 0; pp < players[p].pawns.Count; pp++)
                                    {
                                        for (int googoogaga = 0; googoogaga < players[p]._trail._tails.Count; googoogaga++)
                                        {
                                            if (players[op].IntersectsWithTerritory(players[p]._trail._tails[googoogaga].Hitbox) && p != op)
                                            {
                                                if (players[p].IntersectsWithTrail(players[op].pawns[opp]) && p != op)
                                                {
                                                    players[p].lives--;
                                                }
                                            }
                                        }
                                        for (int e = 0; e < players[op].pawns[opp].arrows.Count - 1; e++)
                                        {
                                            if (players[op].pawns[opp].arrows.Count >= 1 && players[op].pawns[opp].arrows[e].Hitbox.Intersects(players[p].pawns[pp].Hitbox))
                                            {
                                                players[p].pawns[pp]._health -= players[op].pawns[opp]._attack;
                                                players[op].ishitsoundplaying = true;
                                            }
                                        }
                                        for (int e = 0; e < players[op].pawns[opp].bullets.Count - 1; e++)
                                        {
                                            if (players[op].pawns[opp].bullets.Count >= 1 && players[op].pawns[opp].bullets[e].Hitbox.Intersects(players[p].pawns[pp].Hitbox))
                                            {
                                                players[p].pawns[pp]._health -= players[op].pawns[opp]._attack;
                                                players[op].ishitsoundplaying = true;
                                            }
                                        }
                                        for (int e = 0; e < players[op].pawns[opp].balls.Count - 1; e++)
                                        {
                                            if (players[op].pawns[opp].balls.Count >= 1 && players[op].pawns[opp].balls[e].Hitbox.Intersects(players[p].pawns[pp].Hitbox))
                                            {
                                                players[p].pawns[pp]._health -= players[op].pawns[opp]._attack;
                                                players[op].ishitsoundplaying = true;
                                            }
                                        }
                                        if (players[p].pawns.Count > 0 && players[op].pawns.Count > 0)
                                        {
                                            if (players[p].pawns[pp].Hitbox.Intersects(players[op].pawns[opp].Hitbox) && opp != pp && p != op)
                                            {
                                                players[p].pawns[pp].speed = players[op].pawns[opp].speed;
                                                players[op].pawns[opp].speed = players[p].pawns[pp].speed;
                                                players[op].pawns[opp].direction = players[p].pawns[pp].direction;
                                                players[p].pawns[pp].direction = players[op].pawns[opp].direction;
                                                if (players[p].pawns[pp].waitattack >= players[p].pawns[pp].untilattack)
                                                {
                                                    players[op].pawns[opp]._health -= players[p].pawns[pp]._attack;
                                                    players[p].ishitsoundplaying = true;
                                                    players[p].pawns[pp].waitattack = TimeSpan.Zero;
                                                }
                                                if (players[op].pawns[opp].waitattack >= players[op].pawns[opp].untilattack)
                                                {
                                                    players[p].pawns[pp]._health -= players[op].pawns[opp]._attack;
                                                    players[op].ishitsoundplaying = true;
                                                    players[op].pawns[opp].waitattack = TimeSpan.Zero;
                                                }
                                            }
                                            else
                                            {
                                                players[p].pawns[pp].speed = players[p].pawns[pp].prevspeed;
                                                players[op].pawns[opp].speed = players[op].pawns[opp].prevspeed;
                                                players[p].ishitsoundplaying = false;
                                                players[op].ishitsoundplaying = false;
                                            }
                                            if (players[op].ishitsoundplaying)
                                            {
                                                players[op].hassoundstarted = true;
                                                if (players[op].hassoundstarted)
                                                {
                                                    players[op].pawns[opp].PlaySound();
                                                }
                                            }
                                            else
                                            {
                                                players[op].pawns[opp].StopSound();
                                            }
                                            if (players[p].ishitsoundplaying)
                                            {
                                                players[p].hassoundstarted = true;
                                                if (players[p].hassoundstarted)
                                                {
                                                    players[p].pawns[pp].Hit.Play();
                                                }
                                            }
                                            if (players[p].isdead)
                                            {
                                                players[p].pawns.RemoveAt(pp);
                                                pp--;
                                            }
                                            if (players[op].isdead)
                                            {
                                                players[op].pawns.RemoveAt(opp);
                                                opp--;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (somethingHit)
                        {
                            break;
                        }
                        for (int b = 0; b < players[op].booms.Count; b++)
                        {
                            if (players[p].number != 9 && players[p].number != 8)
                            {
                                if (players[p].IntersectsWithTrail(players[op].booms[b]) && op != p || players[op].booms[b].Hitbox.Intersects(players[p].Hitbox) && op != p)
                                {
                                    players[p].lives--;
                                    players[op].booms.RemoveAt(b);
                                    dooms.Add(new Sprite(Content.Load<Texture2D>("boom"), players[p].Location, players[p].colors[players[p].colorselect]));
                                }
                            }

                        }
                    }
                }


                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].captured)
                    {
                        //remove others territory
                        for (int j = 0; j < players.Count; j++)
                        {
                            if (i != j)
                            {
                                players[i].CaptureTerra(players[j]);
                            }
                        }

                        players[i].captured = false;
                    }
                }

                #region blah2
                //if (waitshoot >= tillshoot)
                //{
                //    if (ks.IsKeyDown(Keys.LeftControl))
                //    {
                //        if (number2 == 6)
                //        {
                //            boom bulletToAdd = new boom(Content.Load<Texture2D>("ammo"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), players[count].colors[players[count].colorselect], Type.Bullet, 60);
                //            bulletToAdd.number = player.direction;
                //            players[count].booms.Add(bulletToAdd);
                //        }
                //        if (number2 == 5)
                //        {
                //            boom traptoadd = new boom(Content.Load<Texture2D>("trap"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), players[count].colors[players[count].colorselect], Type.Trap, 0);
                //            traptoadd.number = player.direction;
                //            players[count].booms.Add(traptoadd);
                //        }
                //        if (number2 == 7)
                //        {
                //            boom firetoadd = new boom(Content.Load<Texture2D>("fire"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), players[count].colors[players[count].colorselect], Type.Fire, 30);
                //            firetoadd.number = player.direction;
                //            players[count].booms.Add(firetoadd);
                //        }
                //        if (number2 == 8)
                //        {
                //            boom shurktoadd = new boom(Content.Load<Texture2D>("sh"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), players[count].colors[colorselect], Type.shurk, 25);
                //            shurktoadd.number = player.direction;
                //            players[count].booms.Add(shurktoadd);
                //        }
                //        waitshoot = TimeSpan.Zero;
                //    }

                //}
                #endregion
                for (int e = 0; e < players.Count; e++)
                {
                    for (int i = 0; i < players[e].booms.Count; i++)
                    {
                        players[e].booms[i].Update(gameTime);
                    }
                }

            }
            SamTheCam.Update();
            base.Update(gameTime);
        }
        #region ascii
        //,-----.
        //\======'.
        // \  {}   '.
        //  \   \/ V '.
        //   \  || |   '._                                 _,cmmmnc,_
        //    \___68FS___\'-._=----+- _______________,.-=:3H)###C--  `c._
        //    :|=--------------`---"'`.   `  `.   `.   `,   `~""==="~`    `'-.___
        //  ,dH] '       =(*)=         :       ---==;=--;  .   ;    +-- -_ .-`
        //  :HH]_:______________ ____,.........__ _____,.----=-"~ `
        //  ;:""'"'----._.------\`  :          .   `.'`'"'"'"P
        //  |:      .-'==-.__)___\. :        .   .'`___L ~___(
        //  |:  _.'`       '|   / \.:      .  .-`""`
        //  `'"'            `--'   \:    ._.-'
        //                           }_`============>-


        //                       	                                ,   ,  
        //                                       $,  $,     ,            
        //                                        "ss.$ss. .s'     
        //               	                ,     .ss$$$$$$$$$$s,              
        //                       	        $. s$$$$$$$$$$$$$$`$$Ss
        //                                   "$$$$$$$$$$$$$$$$$$o$$$       ,       
        //                                  s$$$$$$$$$$$$$$$$$$$$$$$$s,  ,s
        //                                 s$$$$$$$$$"$$$$$$""""$$$$$$"$$$$$,   						
        //                       	      s$$$$$$$$$$s""$$$$ssssss"$$$$$$$$"
        //                                $$s$$$$$$$$$$'              					
        //                                s$$$$$$$$$$,             					
        //                                s$$$$$$$$$$$$s,...             						
        //                ssssssz`ssss$$$$$$$$$$$$$$$$$$$$####s.          $$$$$$$
        //                   $$$$$$$$$$$$$$$$$$$$$$$$$$#####$$$$$$"$$$$$$$$$$$$'
        //                    s$$$$$$$$$$$$$$$$$$"$$$$$$$$$$$$$$$$$$$$$####s""     .$$$|
        //                      s$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##ssss.$$" $ 
        //    	                   $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"
        //       	                $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$S$$$$$$$ 
        //               	             ,   ,"     '  $$$$$$$$$$$$$$$$####s  
        //                       	     $.          .s$$$$$$$$$$$$$$$$$####"
        //      		          ,           "$s.   ..ssS$$$$$$$$$$$$$$$$$$$####"
        //              		  $           .$$$S$$$$$$$$$$$$$$$$$$$$$$$$#####"
        //               	 Ss     ..sS$$$$$$$$$$$$$$$$$$$$$$$$$$$######""
        //       	          "$$sS$$$$$$$$$$$$$$$$$$$$$$$$$$$########"
        //       	   ,      s$$$$$$$$$$$$$$$$$$$$$$$$#########""'
        // 	         $    s$$$$$$$$$$$$$$$$$$$$$#######""'      s'         ,
        //  	        $$..$$$$$$$$$$$$$$$$$$######"'       ....,$$....    ,$
        //  	         "$$$$$$$$$$$$$$$######"' ,     .sS$$$$$$$$$$$$$$$$s$$
        //       	      $$$$$$$$$$$$#####"     $, .s$$$$$$$$$$$$$$$$$$$$$$$$s.
        //	  )          $$$$$$$$$$$#####'      `$$$$$$$$$###########$$$$$$$$$$$.
        //  ((          $$$$$$$$$$$#####       $$$$$$$$###"       "####$$$$$$$$$$ 
        //  ) \         $$$$$$$$$$$$####.     $$$$$$###"             "###$$$$$$$$$   s'
        //	(   )        $$$$$$$$$$$$$####.   $$$$$###"                ####$$$$$$$$s$$'
        //	)  ( (       $$"$$$$$$$$$$$#####.$$$$$###'                .###$$$$$$$$$$"
        //	(  )  )   _,$"   $$$$$$$$$$$$######.$$##'                .###$$$$$$$$$$
        // ) (  ( \.         "$$$$$$$$$$$$$#######,,,.          ..####$$$$$$$$$$$"
        //(   )$ )  )        ,$$$$$$$$$$$$$$$$$$####################$$$$$$$$$$$"        
        //(   ($$  ( \     _sS"  `"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$S$$,       
        //	)  )$$$s ) )  .      .   `$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$"'  `$$   
        // 	(   $$$Ss/  .$,    .$,,s$$$$$$##S$$$$$$$$$$$$$$$$$$$$$$$$S""        ' 
        //   	\)_$$$$$$$$$$$$$$$$$$$$$$$##"  $$        `$$.        `$$.
        //       	`"S$$$$$$$$$$$$$$$$$#"      $          `$          `$														
        //                   `"""""""""""""'         '           '           '

        //                 ?                               |||||||
        //                __*_             //              |◘|||◘|
        //             //(____)           //               |||||||
        //            ////○ ○|\          //             ◘◘◘◘◘◘◘◘◘◘◘◘◘ 
        //         ,__///  -  |\        //                ◘◘◘◘◘◘◘◘◘  |||
        //        /  \\   |||  ;       //                             |||
        //       /____\....::./\      //                   
        //      _/__/#\_ _,,_/--\    //                    
        //      /___/######## \/""-(\</                    
        //     _/__/ '#######  ""^(/</                     
        //   __/ /   ,)))=:=(,    //.                      
        //  |,--\   /Q...... /.  (/                        
        //  /       .Q....../..\                           
        //         /.Q ..../...\                           
        //        /......./.....\                          
        //        /...../  \.....\                         
        //        /_.._./   \..._\                         
        //         (` )      (` )                          
        //         | /        \ |                          
        //         '(          )'                          
        //        /+|          |+\                         
        //        |,/          \,/                         
        //        [|||]	        [|||]  



        //         __,='`````'=/__
        //        '//  (o) \(o) \ `'         _,-,
        //        //|     ,_)   (`\      ,-'`_,-\
        //      ,-~~~\  `'==='  /-,      \==```` \__
        //     /        `----'     `\     \       \/
        //  ,-`                  ,   \  ,.-\       \
        // /      ,               \,-`\`_,-`\_,..--'\
        //,`    ,/,              ,>,   )     \--`````\
        //(      `\`---'`  `-,-'`_,<   \      \_,.--'`
        // `.      `--. _,-'`_,-`  |    \
        //  [`-.___<`_,-'`------(    /
        //  (`` _,-\   \ --`````````|--`
        //   >-`_,-`\,-` ,          |
        // <`_,'     ,  /\          /
        //  `  \/\,-/ `/  \/`\_/V\_/
        //     (  ._. )    ( .__. )
        //     |      |    |      |
        //      \,---_|    |_---./
        //      ooOO(_)    (_)OOoo


        //  _..----.._                                   
        //                                              ]_.--._____[
        //                                            ___ | '--'__..| --._
        //                        __               """    ;            :                              
        //                      ()_ """"-- -...__.'""!":  /    ___       :                             
        //                         """---...__\]..__] | /    [ 0 ]      :                             
        //                                    """!--./ /      """        :                            
        //                             __...._____;""'.__________..--..:_                           
        //                            /  !"''''''!''''''''''|''''/' ' ' ' \"--..__  __..              
        //                           /  /.--.    |          |  .'          \' ' '.""--.{'.            
        //       _...__            >=7 //.-.:    |          |.'             \ ._.__  ' '""'.          
        //    .-' /    """"----..../ "">==7-.....:______    |                \| |  "";.;-"> \         
        //    """";           __.."   .--"/"""""----...."""""----.....H_______\_!....'----""""]       
        //  _..---|._ __..--""       _!.-=_.            """""""""""""""                   ;"""        
        // /   .-";-.'--...___     ." .-""; ';""-""-...^..__...-v.^___,  ,__v.__..--^"--""-v.^v,      
        //;   ;   |'.         """-/ ./;  ;   ;\P.        ;   ;        """"____;  ;.--""""// '""<,     
        //;   ;   | 1            ;  ;  '.: .'  ;<   ___.-'._.'------""""""____'..'.--""";;'  o ';     
        //'.   \__:/__           ;  ;--""()_   ;'  /___.-" ____---""""""" __.._ __._   '>.,  ,/;     
        //  \   \    /"""<--...__;  '_.-'/; ""; ;.'.'  "-..'    "-.      /"/    `__. '.   "---";      
        //   '.  'v ; ;     ;;    \  \ .'  \ ; ////    _.-" "-._   ;    : ;   .-'__ '. ;   .^".'      
        //     '.  '; '.   .'/     '. `-.__.' /;;;   .o__.---.__o. ;    : ;   '"";;""' ;v^" .^        
        //       '-. '-.___.'<__v.^,v'.  '-.-' ;|:   '    :      ` ;v^v^'.'.    .;'.__/_..-'          
        //          '-...__.___...---""'-.   '-'.;\     'WW\     .'_____..>."^"-""""""""    fsc       
        //                                '--..__ '"._..'  '"-;;"""                                   
        //                                       """---'""""""                                        

        //             |\                |\                |\                |\
        //   || .---.          || .---.          || .---.          || .---.
        //   ||/_____\         ||/_____\         ||/_____\         ||/_____\
        //   ||( '.' )         ||( '.' )         ||( '.' )         ||( '.' )
        //   || \_-_/_         || \_-_/_         || \_-_/_         || \_-_/_
        //   :-"`'V'//-.       :-"`'V'//-.       :-"`'V'//-.       :-"`'V'//-.
        //  / ,   |// , `\    / ,   |// , `\    / ,   |// , `\    / ,   |// , `\
        // / /|Ll //Ll|| |   / /|Ll //Ll|| |   / /|Ll //Ll|| |   / /|Ll //Ll|| |
        ///_/||__//   || |  /_/||__//   || |  /_/||__//   || |  /_/||__//   || |
        //\ \/---|[]==|| |  \ \/---|[]==|| |  \ \/---|[]==|| |  \ \/---|[]==|| |
        // \/\__/ |   \| |   \/\__/ |   \| |   \/\__/ |   \| |   \/\__/ |   \| |
        // /\|_   | Ll_\ |   /|/_   | Ll_\ |   /|/_   | Ll_\ |   /|/_   | Ll_\ |
        // `--|`^"""^`||_|   `--|`^"""^`||_|   `--|`^"""^`||_|   `--|`^"""^`||_|
        //    |   |   ||/       |   |   ||/       |   |   ||/       |   |   ||/
        //    |   |   |         |   |   |         |   |   |         |   |   |
        //    |   |   |         |   |   |         |   |   |         |   |   |
        //    |   |   |         |   |   |         |   |   |         |   |   |
        //    L___l___J         L___l___J         L___l___J         L___l___J
        //     |_ | _|           |_ | _|           |_ | _|           |_ | _|
        //    (___|___)         (___|___)         (___|___)         (___|___)
        //     ^^^ ^^^           ^^^ ^^^           ^^^ ^^^           ^^^ ^^^
        #endregion







        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, SamTheCam.Effect);
            backimage.draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, SamTheCam.Effect);
            if (!menu)
            {
                grid.Draw(spriteBatch);
                for(int i = 0; i < baddies.Count; i++)
                {
                    baddies[i].draw(spriteBatch);
                }
                for (int i = 0; i < goodies.Count; i++)
                {
                    goodies[i].draw(spriteBatch);
                    goodies[i].rotordraw(spriteBatch);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].isdead == false)
                    {
                        players[i].TerraDraw(spriteBatch);
                    }
                }
                for (int e = 0; e < players.Count; e++)
                {
                    if (players[e].isdead == false)
                    {
                        players[e].TrailDraw(spriteBatch);
                        players[e].Pawndraw(spriteBatch);
                        players[e].Playerdraw(spriteBatch);
                    }
                    if (players[e].isboom)
                    {
                        for (int i = 0; i < players[e].booms.Count; i++)
                        {
                            players[e].booms[i].draw(spriteBatch);
                        }
                    }
                    if (players[e].isdead)
                    {
                        death.draw(spriteBatch);
                    }
                }
                for (int i = 0; i < dooms.Count; i++)
                {
                    dooms[i].draw(spriteBatch);
                }
                // players[e].debugDraw(spriteBatch, Content.Load<Texture2D>("pixel"));
            }
            spriteBatch.End();


            //ui
            spriteBatch.Begin();
            if (menu)
            {
                GraphicsDevice.Clear(players[count].colors[players[count].colorselect]);
                killbutt.draw(spriteBatch);
                movebutt.draw(spriteBatch);
                stanbutt.draw(spriteBatch);
                regbutt.draw(spriteBatch);
                soldierbutt.draw(spriteBatch);
                trapbutt.draw(spriteBatch);
                huntbutt.draw(spriteBatch);
                wizbutt.draw(spriteBatch);
                ninjabutt.draw(spriteBatch);
                phantombutt.draw(spriteBatch);
                kingbutt.draw(spriteBatch);
                rules.draw(spriteBatch);
                title.draw(spriteBatch);
            }
            else
            {
                health.draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
