﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Template/DataTemplate")]
    public class PublicDataTemplateTest
    {
        private const string tag = "NUITEST";
        private static readonly Condition condition;

        private void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)oldValue == (bool)newValue) return;

            condition.ConditionChanged?.Invoke(bindable, (bool)oldValue, (bool)newValue);
        }

        internal class MyDataTemplateTest : DataTemplate
        {
            public MyDataTemplateTest() : base()
            { }

            public void OnSetupContent(object value)
            {
                base.SetupContent(value);
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate constructor.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.DataTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateConstructor()
        {
            tlog.Debug(tag, $"DataTemplateConstructor START");

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            tlog.Debug(tag, $"DataTemplateConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate constructor. With Type.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.DataTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateConstructorWithType()
        {
            tlog.Debug(tag, $"DataTemplateConstructorWithType START");

            string str = "myDataTemplate";
#pragma warning disable Reflection // The code contains reflection
            var testingTarget = new DataTemplate(str.GetType());
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            tlog.Debug(tag, $"DataTemplateConstructorWithType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate constructor. With Func.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.DataTemplate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateConstructorWithFunc()
        {
            tlog.Debug(tag, $"DataTemplateConstructorWithFunc START");

            Func<object> LoadTemplate = () => new View();

            var testingTarget = new DataTemplate(LoadTemplate);
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            tlog.Debug(tag, $"DataTemplateConstructorWithFunc END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetBinding.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetBinding()
        {
            tlog.Debug(tag, $"DataTemplateSetBinding START");

            BindingBase binding = new Tizen.NUI.Binding.Binding() as BindingBase;
#pragma warning disable Reflection // The code contains reflection
            BindableProperty stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
#pragma warning restore Reflection // The code contains reflection

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            try
            {
                testingTarget.SetBinding(stateProperty, binding);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DataTemplateSetBinding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetBinding. With null BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetBindingWithNullBindableProperty()
        {
            tlog.Debug(tag, $"DataTemplateSetBindingWithNullBindableProperty START");

            BindingBase binding = new Tizen.NUI.Binding.Binding() as BindingBase;

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            try
            {
                testingTarget.SetBinding(null, binding);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"DataTemplateSetValueWithNullBindableProperty END (OK)");
                Assert.Pass("Caught ArgumentNullException: Pass!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetBinding. With null BindingBase.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetBinding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetBindingWithNullBindingBase()
        {
            tlog.Debug(tag, $"DataTemplateSetBindingWithNullBindingBase START");

#pragma warning disable Reflection // The code contains reflection
            BindableProperty stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
#pragma warning restore Reflection // The code contains reflection

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            try
            {
                testingTarget.SetBinding(stateProperty, null);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"DataTemplateSetValueWithNullBindableProperty END (OK)");
                Assert.Pass("Caught ArgumentNullException: Pass!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetValue.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetValue()
        {
            tlog.Debug(tag, $"DataTemplateSetValue START");

#pragma warning disable Reflection // The code contains reflection
            BindableProperty stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
#pragma warning restore Reflection // The code contains reflection

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            try
            {
                testingTarget.SetValue(stateProperty, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DataTemplateSetValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetValue. With null BindableProperty.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetValueWithNullBindableProperty()
        {
            tlog.Debug(tag, $"DataTemplateSetValueWithNullBindableProperty START");

            var testingTarget = new DataTemplate();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            try
            {
                testingTarget.SetValue(null, true);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"DataTemplateSetValueWithNullBindableProperty END (OK)");
                Assert.Pass("Caught ArgumentNullException: Pass!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("DataTemplate SetupContent. With null bandable.")]
        [Property("SPEC", "Tizen.NUI.DataTemplate.SetupContent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DataTemplateSetupContentWithNullBindable()
        {
            tlog.Debug(tag, $"DataTemplateSetupContentWithNullBindable START");

            BindingBase binding = new Tizen.NUI.Binding.Binding() as BindingBase;
#pragma warning disable Reflection // The code contains reflection
            BindableProperty stateProperty = BindableProperty.CreateAttached("State", typeof(bool), typeof(XamlPropertyCondition), false, propertyChanged: OnStatePropertyChanged);
#pragma warning restore Reflection // The code contains reflection

            var testingTarget = new MyDataTemplateTest();
            Assert.IsNotNull(testingTarget, "Can't create success object DataTemplate");
            Assert.IsInstanceOf<DataTemplate>(testingTarget, "Should be an instance of DataTemplate type.");

            testingTarget.SetBinding(stateProperty, binding);

            try
            {
                testingTarget.OnSetupContent(null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"DataTemplateSetupContentWithNullBindable END (OK)");
        }

    }
}
