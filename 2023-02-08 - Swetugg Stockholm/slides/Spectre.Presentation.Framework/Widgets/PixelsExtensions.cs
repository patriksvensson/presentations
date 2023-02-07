using System;
using SixLabors.ImageSharp.Processing;

namespace Spectre.Presentation.Framework;

/// <summary>
/// Contains extension methods for <see cref="Pixels"/>.
/// </summary>
public static class PixelsExtensions
{
    /// <summary>
    /// Sets the pixel width.
    /// </summary>
    /// <param name="image">The canvas image.</param>
    /// <param name="width">The pixel width.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static Pixels PixelWidth(this Pixels image, int width)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        image.PixelWidth = width;
        return image;
    }

    /// <summary>
    /// Mutates the underlying image.
    /// </summary>
    /// <param name="image">The canvas image.</param>
    /// <param name="action">The action that mutates the underlying image.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static Pixels Mutate(this Pixels image, Action<IImageProcessingContext> action)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        if (action is null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        image.Image.Mutate(action);
        return image;
    }

    /// <summary>
    /// Uses a bicubic sampler that implements the bicubic kernel algorithm W(x).
    /// </summary>
    /// <param name="image">The canvas image.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static Pixels BicubicResampler(this Pixels image)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        image.Resampler = KnownResamplers.Bicubic;
        return image;
    }

    /// <summary>
    /// Uses a bilinear sampler. This interpolation algorithm
    /// can be used where perfect image transformation with pixel matching is impossible,
    /// so that one can calculate and assign appropriate intensity values to pixels.
    /// </summary>
    /// <param name="image">The canvas image.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static Pixels BilinearResampler(this Pixels image)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        image.Resampler = KnownResamplers.Triangle;
        return image;
    }

    /// <summary>
    /// Uses a Nearest-Neighbour sampler that implements the nearest neighbor algorithm.
    /// This uses a very fast, unscaled filter which will select the closest pixel to
    /// the new pixels position.
    /// </summary>
    /// <param name="image">The canvas image.</param>
    /// <returns>The same instance so that multiple calls can be chained.</returns>
    public static Pixels NearestNeighborResampler(this Pixels image)
    {
        if (image is null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        image.Resampler = KnownResamplers.NearestNeighbor;
        return image;
    }
}