/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Template that specifies a group of styles and effects for controls.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ControlTemplate : ElementTemplate
    {
        /// <summary>
        /// For internal use only.
        /// </summary>
        public ControlTemplate()
        {
        }

        /// <summary>
        /// Creates a new control template for the specified control type.
        /// </summary>
        /// <param name="type">The type of control for which to create a template.</param>
        public ControlTemplate(Type type) : base(type)
        {
        }
    }
}
 
