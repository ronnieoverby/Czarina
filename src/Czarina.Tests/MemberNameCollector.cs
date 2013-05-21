using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Czarina.Tests
{
    public class MemberNameCollector : DynamicObject
    {
        private readonly HashSet<string> _members = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _members;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            _members.Add(binder.Name);
            result = this;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _members.Add(binder.Name);
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            _members.Add(binder.Name);
            result = this;
            return true;
        }
    }
}