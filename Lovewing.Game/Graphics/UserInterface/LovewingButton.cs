﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input;
using osu.Framework.Extensions.Color4Extensions;
using OpenTK;
using OpenTK.Graphics;

namespace Lovewing.Game.Graphics.UserInterface
{
    class LovewingButton : Button, IFilterable
    {
        private readonly Box hover;

        public Color4 BackgroundColor
        {
            get { return Background.Colour; }
            set { Background.FadeColour(value); }
        }

        public Color4 HoverColor
        {
            get { return hover.Colour; }
            set { hover.FadeColour(value); }
        }

        public Color4 TextColor
        {
            get { return SpriteText.Colour; }
            set { SpriteText.FadeColour(value); }
        }

        public float TextY
        {
            get { return SpriteText.Y; }
            set { SpriteText.MoveToY(value); }
        }

        public LovewingButton(float textX = 0, float textY = 60, float textSize = 30)
        {
            Height = 40;
            Masking = true;
            CornerRadius = 5;
            AddInternal(new Drawable[]
            {
                Background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Depth = 5,
                },
                SpriteText = CreateText(),
                hover = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    BlendingMode = BlendingMode.Additive,
                    Colour = Color4.White.Opacity(0.1f),
                    Alpha = 0,
                },
            });

            SpriteText.X = textX;
            SpriteText.Y = 60;
            SpriteText.TextSize = textSize;
            SpriteText.Shadow = true;
        }

        [BackgroundDependencyLoader]
        public void load(LovewingColors colors)
        {
            BackgroundColour = colors.Magenta;
        }

        protected override bool OnClick(InputState state)
        {
            return base.OnClick(state);
        }

        protected override bool OnHover(InputState state)
        {
            hover.FadeIn(200);
            return base.OnHover(state);
        }

        protected override void OnHoverLost(InputState state)
        {
            hover.FadeOut(200);
            base.OnHoverLost(state);
        }

        protected override bool OnMouseUp(InputState state, MouseUpEventArgs args)
        {
            Content.ScaleTo(1.1f, 1000, EasingTypes.OutElastic);
            return base.OnMouseUp(state, args);
        }

        public string[] FilterTerms => new[] { Text };

        public bool MatchingFilter
        {
            set
            {
                this.FadeTo(value ? 1 : 0);
            }
        }
    }
}