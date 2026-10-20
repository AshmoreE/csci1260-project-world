# CSCI 1260 Project 1 - Streaming Library

## Student Information

**Name:** Ethan Ashmore
**Section:** 002
**World:** Movie Streaming Library
**Language:** C#

## Project Description

My project is a streaming library that manages different types of media, including movies, TV series, and audiobooks. The program also tracks viewing or listening activity for media items.

## Design Questions

### 1. Explain Both Diamonds

The aggregation relationship in my project is between 'StreamingLibrary' and 'MediaItem'. 'Program' creates the media items and then passes them to the library using the 'Add()' method. The library stores the media items, but it does not create them. This means the media items can exist independently of the library, which is why i used a hollow diamond for aggregation. If I changed 'StreamingLibrary' so that it created the media items itself instead of receiving existing objects through 'Add()', this relationship would no longer work the same way as aggregation.
The composition relationship is between 'MediaItem' and 'ViewingRecord'. A 'MediaItem' creates its own 'ViewingRecord' objects inside the 'RecordActivity' method and keeps them in its private list. 'Program' does not create the viewing records directly. The records belond to the media item and are treated as part of it, which is why i used a filled diamond for composition. If viewing records were created outside of 'MediaItem' and passed into it, the relationship would no longer represent the same strong ownership.

### 2. Why I Used IDownloadable

I created the `IDownloadable` interface to represent media that has the ability to be downloaded. `Movie` and `Audiobook` both implement `IDownloadable`, even though they are on different branches of my inheritance hierarchy.

I did not put `DownloadInfo()` in the `MediaItem` base class because not every media type in my project needs to be downloadable. For example, `TVSeries` does not implement the interface. Using an interface lets different types share the same capability without forcing every `MediaItem` to have that behavior.

### 3. Adding a New Media Type

If I wanted to add another type of media, I would create a new class for that media type and inherit from either `MediaItem` or `VideoMedia`, depending on what kind of media it is. The new class would implement the required abstract methods such as `GetMediaType()` and `GetDurationMinutes()`. It would also override `Describe()` and call `base.Describe()` so it follows the same design as the existing classes.

If the new media type could be downloaded, I could also have it implement `IDownloadable`. The `StreamingLibrary` manager should not need to be changed because it stores objects using the `MediaItem` base type. This lets a new `MediaItem` subclass be added to the library without changing how the manager works.

## Recording

**Code Review Recording:** [Add recording link here]

## Incomplete Items

None.