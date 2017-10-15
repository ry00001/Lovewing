﻿// Copyright (c) 2017 Clara.
// Licensed under the EPL-1.0 License

using Lovewing.Game.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace Lovewing.Game.Graphics.Overlay
{
    public class Inbox : OverlayContainer
    {
        public Inbox()
        {
            Height = 500;
            Width = 500;
            Depth = -1;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Masking = true;
            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Radius = 10,
                Colour = Color4.Black.Opacity(0.5f),
            };
        }

        [BackgroundDependencyLoader]
        private void load(LovewingColors colors)
        {

            AddRangeInternal(new Drawable[]
            {
                new IconButton
                {
                    Icon = FontAwesome.fa_server,
                    Colour = colors.Magenta,
                    Size = new Vector2(20),
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Margin = new MarginPadding
                    {
                        Top = 40,
                        Left = 90,
                    },
                },
                new LovewingSearchBox
                {
                    CommitColour = colors.LightMagenta,
                    UnfocusedColour = colors.White,
                    FocusedColour = colors.LightMagenta,
                    PlaceholderColour = colors.Magenta,
                    TextColour = colors.Magenta,
                    Margin = new MarginPadding { Top = 25 },
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Size = new Vector2(200, 50),
                    Colour = colors.White,
                    BorderColour = colors.Magenta,
                    BorderThickness = 5,
                },
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = colors.White,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Depth = 5,
                }
            });
        }

        protected override void PopIn()
        {
            Content.FadeInFromZero(250);
        }

        protected override void PopOut()
        {
            Content.FadeOutFromOne(250);
        }
    }
}
