﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2016 Realm Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
////////////////////////////////////////////////////////////////////////////

using System;

namespace Realms
{
    // Tell the linker to preserve a class or method even if it looks like it's not invoked.
    // Since it matches by name, it works to just declare it here.
    [AttributeUsage(System.AttributeTargets.All)]
    public sealed class PreserveAttribute : Attribute
    {

        public bool AllMembers;
        public bool Conditional;

        public PreserveAttribute(string reason = null)
        {
        }

        public PreserveAttribute(Type type)
        {
        }
    }
}

