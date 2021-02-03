# CarouselRegression

This sample demonstrates strange rendering behaviour in the CarouselView control from at least build 5.0.0.1874 and is still present in build 5.0.0.1931.

The sample works correctly in Build 4.8.0.1821.

UPDATE

Forms 5 introduces a new property called `Loop` which rotates items from the beginning. This property is set to `true` by default.
When nuget is upgraded from 4.8, looping is therefore enabled by default. Unfortuneately there is still a bug with looping items in a collection and using a `ContentView` inside the `ItemTemplate`.

Turning off loop for now, resolves this issue and restores behaviour to 4.8.
