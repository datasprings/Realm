////////////////////////////////////////////////////////////////////////////
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
using System.Diagnostics;

namespace Realms
{
    public class Migration
    {
        private readonly Realm oldRealm;
        private readonly Realm newRealm;

        public delegate void EnumerationDelegate<T>(dynamic oldObject, T newObject) where T : RealmObject;

        public void Enumerate<T>(EnumerationDelegate<T> enumerator) where T : RealmObject
        {
            var oldItems = oldRealm.All<T>();
            var newItems = newRealm.All<T>();

            var count = newItems.Count();
            Debug.Assert(oldItems.Count() == count);

            for (var i = 0; i < count; i++)
            {
                enumerator(oldItems[i], newItems[i]);
            }
        }

        public void RenameProperty<T>(string oldName, string newName) where T : RealmObject
        {
            throw new NotImplementedException();
        }

        public void Remove(RealmObject obj)
        {
            newRealm.Remove(obj);
        }

        public void RemoveAll<T>() where T : RealmObject
        {
            newRealm.RemoveAll<T>();
        }

        public T CreateObject<T>() where T : RealmObject, new()
        {
            return newRealm.CreateObject<T>();
        }
    }
}

