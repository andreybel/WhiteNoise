using System.Collections;
using Xamarin.Forms;

namespace WhiteNoiseApp.Controls
{
    public class ListFlexLayout : FlexLayout
    {

        public ListFlexLayout()
        {

        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: nameof(ItemsSource),
            returnType: typeof(IEnumerable),
            declaringType: typeof(ListFlexLayout),
            defaultValue: default(IEnumerable),
            defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourcePropertyChanged);


        public static readonly BindableProperty ColumnCountProperty = BindableProperty.Create(
            propertyName: nameof(ColumnCount),
            returnType: typeof(int),
            declaringType: typeof(ListFlexLayout),
            defaultValue: 1,
            defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ListFlexLayout), null,
                validateValue: (b, v) => ((ListFlexLayout)b).ValidateItemTemplate((DataTemplate)v));

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ListFlexLayout layout && newValue is IEnumerable items)
            {
                if (layout.ItemTemplate != null)
                {
                    layout.Children.Clear();
                    foreach (object item in items)
                    {
                        if (layout.ItemTemplate is DataTemplateSelector selector)
                        {
                            if (selector.SelectTemplate(item, layout)?.CreateContent() is View content)
                            {
                                layout.AddChild(content, item);
                            }
                        }
                        else
                        {
                            if (layout.ItemTemplate.CreateContent() is View content)
                            {
                                layout.AddChild(content, item);
                            }
                        }

                    }
                    layout.InvalidateLayout();
                }
            }
        }

        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false;
        }

        protected override bool ShouldInvalidateOnChildRemoved(View child)
        {
            return false;
        }

        private void AddChild(View content, object binding)
        {
            content.BindingContext = binding;
            content.WidthRequest = Device.Info.ScaledScreenSize.Width / this.ColumnCount;
            this.Children.Add(content);
        }

        public int ColumnCount
        {
            get => (int)GetValue(ColumnCountProperty);
            set => SetValue(ColumnCountProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        protected virtual bool ValidateItemTemplate(DataTemplate template) => true;
    }
}
