﻿using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    /// <summary>
    /// ColumnResizer is a UI control that add the resizing functionality to a Grid Column.
    /// </summary>
    [TemplatePart(Name = SPLITTERRNAME, Type = typeof(Thumb))]
    public partial class GridSplitter : Control
    {
        private const string SPLITTERRNAME = "Splitter";
        private static readonly CoreCursor ColumnsSplitterCursor = new CoreCursor(CoreCursorType.SizeWestEast, 1);
        private static readonly CoreCursor RowSplitterCursor = new CoreCursor(CoreCursorType.SizeNorthSouth, 1);
        private static readonly CoreCursor ArrowCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        private Thumb _splitter;

        /// <summary>
        /// Gets Column Resizer Container Grid
        /// </summary>
        private Grid Resizable => this.Parent as Grid;

        /// <summary>
        /// Gets the current Column definition of the parent Grid
        /// </summary>
        private ColumnDefinition CurrentColumn
        {
            get
            {
                if (Resizable == null)
                {
                    return null;
                }

                var gridSplitterTargetedColumnIndex = Grid.GetColumn(this);

                if ((gridSplitterTargetedColumnIndex >= 0)
                    && (gridSplitterTargetedColumnIndex < Resizable.ColumnDefinitions.Count))
                {
                    return Resizable.ColumnDefinitions[gridSplitterTargetedColumnIndex];
                }

                return null;
            }
        }

        private RowDefinition CurrentRow
        {
            get
            {
                if (Resizable == null)
                {
                    return null;
                }

                var gridSplitterTargetedRowIndex = Grid.GetRow(this);

                if ((gridSplitterTargetedRowIndex >= 0)
                    && (gridSplitterTargetedRowIndex < Resizable.RowDefinitions.Count))
                {
                    return Resizable.RowDefinitions[gridSplitterTargetedRowIndex];
                }

                return null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridSplitter"/> class.
        /// </summary>
        public GridSplitter()
        {
            this.DefaultStyleKey = typeof(GridSplitter);
        }

        /// <inheritdoc />
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _splitter = GetTemplateChild(SPLITTERRNAME) as Thumb;
            if (_splitter == null)
            {
                return;
            }

            _splitter.DragStarted += Splitter_DragStarted;
            _splitter.DragDelta += Splitter_DragDelta;
            _splitter.DragCompleted += Splitter_DragCompleted;

            if (ResizeDirection == ResizeDirection.Columns)
            {
                // To overcome the relative column width resize issues etc: Width=*
                CurrentColumn.Width = new GridLength(CurrentColumn.ActualWidth);
            }
            else if (ResizeDirection == ResizeDirection.Rows)
            {
                // To overcome the relative row height resize issues etc: height=*
                CurrentRow.Height = new GridLength(CurrentRow.ActualHeight);
            }
        }
    }
}
