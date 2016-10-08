






namespace AutoWrapper.Examples.DirectoryServices
{
/*
internal interface IActiveDirectorySecurity {
    
    System.Type AccessRightType {
        get;
    }
    
    System.Type AccessRuleType {
        get;
    }
    
    System.Type AuditRuleType {
        get;
    }
    
    bool AreAccessRulesProtected {
        get;
    }
    
    bool AreAuditRulesProtected {
        get;
    }
    
    bool AreAccessRulesCanonical {
        get;
    }
    
    bool AreAuditRulesCanonical {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurity Wrapped {
        get;
    }
    
    void AddAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule);
    
    void SetAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule);
    
    void ResetAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule);
    
    void RemoveAccess(System.Security.Principal.IdentityReference identity, System.Security.AccessControl.AccessControlType type);
    
    bool RemoveAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule);
    
    void RemoveAccessRuleSpecific(System.DirectoryServices.ActiveDirectoryAccessRule rule);
    
    bool ModifyAccessRule(System.Security.AccessControl.AccessControlModification modification, System.Security.AccessControl.AccessRule rule, System.Boolean& modified);
    
    void PurgeAccessRules(System.Security.Principal.IdentityReference identity);
    
    void AddAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule);
    
    void SetAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule);
    
    void RemoveAudit(System.Security.Principal.IdentityReference identity);
    
    bool RemoveAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule);
    
    void RemoveAuditRuleSpecific(System.DirectoryServices.ActiveDirectoryAuditRule rule);
    
    bool ModifyAuditRule(System.Security.AccessControl.AccessControlModification modification, System.Security.AccessControl.AuditRule rule, System.Boolean& modified);
    
    void PurgeAuditRules(System.Security.Principal.IdentityReference identity);
    
    System.Security.AccessControl.AccessRule AccessRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AccessControlType type);
    
    System.Security.AccessControl.AccessRule AccessRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AccessControlType type, System.Guid objectGuid, System.Guid inheritedObjectGuid);
    
    System.Security.AccessControl.AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AuditFlags flags);
    
    System.Security.AccessControl.AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AuditFlags flags, System.Guid objectGuid, System.Guid inheritedObjectGuid);
    
    System.Security.AccessControl.AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited, System.Type targetType);
    
    System.Security.AccessControl.AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited, System.Type targetType);
    
    byte[] GetSecurityDescriptorBinaryForm();
    
    System.Security.Principal.IdentityReference GetOwner(System.Type targetType);
    
    void SetOwner(System.Security.Principal.IdentityReference identity);
    
    System.Security.Principal.IdentityReference GetGroup(System.Type targetType);
    
    void SetGroup(System.Security.Principal.IdentityReference identity);
    
    void SetAccessRuleProtection(bool isProtected, bool preserveInheritance);
    
    void SetAuditRuleProtection(bool isProtected, bool preserveInheritance);
    
    string GetSecurityDescriptorSddlForm(System.Security.AccessControl.AccessControlSections includeSections);
    
    void SetSecurityDescriptorSddlForm(string sddlForm);
    
    void SetSecurityDescriptorSddlForm(string sddlForm, System.Security.AccessControl.AccessControlSections includeSections);
    
    void SetSecurityDescriptorBinaryForm(byte[] binaryForm);
    
    void SetSecurityDescriptorBinaryForm(byte[] binaryForm, System.Security.AccessControl.AccessControlSections includeSections);
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySecurity
{
    
    private System.DirectoryServices.ActiveDirectorySecurity _wrapped;
    
    public WrappedActiveDirectorySecurity(System.DirectoryServices.ActiveDirectorySecurity wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.Type AccessRightType
    {
        get
        {
            return this._wrapped.AccessRightType;
        }
    }
    
    public virtual System.Type AccessRuleType
    {
        get
        {
            return this._wrapped.AccessRuleType;
        }
    }
    
    public virtual System.Type AuditRuleType
    {
        get
        {
            return this._wrapped.AuditRuleType;
        }
    }
    
    public virtual bool AreAccessRulesProtected
    {
        get
        {
            return this._wrapped.AreAccessRulesProtected;
        }
    }
    
    public virtual bool AreAuditRulesProtected
    {
        get
        {
            return this._wrapped.AreAuditRulesProtected;
        }
    }
    
    public virtual bool AreAccessRulesCanonical
    {
        get
        {
            return this._wrapped.AreAccessRulesCanonical;
        }
    }
    
    public virtual bool AreAuditRulesCanonical
    {
        get
        {
            return this._wrapped.AreAuditRulesCanonical;
        }
    }
    
    public virtual void AddAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule)
    {
        this._wrapped.AddAccessRule(rule);
    }
    
    public virtual void SetAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule)
    {
        this._wrapped.SetAccessRule(rule);
    }
    
    public virtual void ResetAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule)
    {
        this._wrapped.ResetAccessRule(rule);
    }
    
    public virtual void RemoveAccess(System.Security.Principal.IdentityReference identity, System.Security.AccessControl.AccessControlType type)
    {
        this._wrapped.RemoveAccess(identity, type);
    }
    
    public virtual bool RemoveAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule rule)
    {
        return this._wrapped.RemoveAccessRule(rule);
    }
    
    public virtual void RemoveAccessRuleSpecific(System.DirectoryServices.ActiveDirectoryAccessRule rule)
    {
        this._wrapped.RemoveAccessRuleSpecific(rule);
    }
    
    public virtual bool ModifyAccessRule(System.Security.AccessControl.AccessControlModification modification, System.Security.AccessControl.AccessRule rule, System.Boolean& modified)
    {
        return this._wrapped.ModifyAccessRule(modification, rule, modified);
    }
    
    public virtual void PurgeAccessRules(System.Security.Principal.IdentityReference identity)
    {
        this._wrapped.PurgeAccessRules(identity);
    }
    
    public virtual void AddAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule)
    {
        this._wrapped.AddAuditRule(rule);
    }
    
    public virtual void SetAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule)
    {
        this._wrapped.SetAuditRule(rule);
    }
    
    public virtual void RemoveAudit(System.Security.Principal.IdentityReference identity)
    {
        this._wrapped.RemoveAudit(identity);
    }
    
    public virtual bool RemoveAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule rule)
    {
        return this._wrapped.RemoveAuditRule(rule);
    }
    
    public virtual void RemoveAuditRuleSpecific(System.DirectoryServices.ActiveDirectoryAuditRule rule)
    {
        this._wrapped.RemoveAuditRuleSpecific(rule);
    }
    
    public virtual bool ModifyAuditRule(System.Security.AccessControl.AccessControlModification modification, System.Security.AccessControl.AuditRule rule, System.Boolean& modified)
    {
        return this._wrapped.ModifyAuditRule(modification, rule, modified);
    }
    
    public virtual void PurgeAuditRules(System.Security.Principal.IdentityReference identity)
    {
        this._wrapped.PurgeAuditRules(identity);
    }
    
    public virtual System.Security.AccessControl.AccessRule AccessRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AccessControlType type)
    {
        return this._wrapped.AccessRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);
    }
    
    public virtual System.Security.AccessControl.AccessRule AccessRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AccessControlType type, System.Guid objectGuid, System.Guid inheritedObjectGuid)
    {
        return this._wrapped.AccessRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type, objectGuid, inheritedObjectGuid);
    }
    
    public virtual System.Security.AccessControl.AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AuditFlags flags)
    {
        return this._wrapped.AuditRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);
    }
    
    public virtual System.Security.AccessControl.AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, System.Security.AccessControl.InheritanceFlags inheritanceFlags, System.Security.AccessControl.PropagationFlags propagationFlags, System.Security.AccessControl.AuditFlags flags, System.Guid objectGuid, System.Guid inheritedObjectGuid)
    {
        return this._wrapped.AuditRuleFactory(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags, objectGuid, inheritedObjectGuid);
    }
    
    public virtual System.Security.AccessControl.AuthorizationRuleCollection GetAccessRules(bool includeExplicit, bool includeInherited, System.Type targetType)
    {
        return this._wrapped.GetAccessRules(includeExplicit, includeInherited, targetType);
    }
    
    public virtual System.Security.AccessControl.AuthorizationRuleCollection GetAuditRules(bool includeExplicit, bool includeInherited, System.Type targetType)
    {
        return this._wrapped.GetAuditRules(includeExplicit, includeInherited, targetType);
    }
    
    public virtual byte[] GetSecurityDescriptorBinaryForm()
    {
        return this._wrapped.GetSecurityDescriptorBinaryForm();
    }
    
    public virtual System.Security.Principal.IdentityReference GetOwner(System.Type targetType)
    {
        return this._wrapped.GetOwner(targetType);
    }
    
    public virtual void SetOwner(System.Security.Principal.IdentityReference identity)
    {
        this._wrapped.SetOwner(identity);
    }
    
    public virtual System.Security.Principal.IdentityReference GetGroup(System.Type targetType)
    {
        return this._wrapped.GetGroup(targetType);
    }
    
    public virtual void SetGroup(System.Security.Principal.IdentityReference identity)
    {
        this._wrapped.SetGroup(identity);
    }
    
    public virtual void SetAccessRuleProtection(bool isProtected, bool preserveInheritance)
    {
        this._wrapped.SetAccessRuleProtection(isProtected, preserveInheritance);
    }
    
    public virtual void SetAuditRuleProtection(bool isProtected, bool preserveInheritance)
    {
        this._wrapped.SetAuditRuleProtection(isProtected, preserveInheritance);
    }
    
    public virtual string GetSecurityDescriptorSddlForm(System.Security.AccessControl.AccessControlSections includeSections)
    {
        return this._wrapped.GetSecurityDescriptorSddlForm(includeSections);
    }
    
    public virtual void SetSecurityDescriptorSddlForm(string sddlForm)
    {
        this._wrapped.SetSecurityDescriptorSddlForm(sddlForm);
    }
    
    public virtual void SetSecurityDescriptorSddlForm(string sddlForm, System.Security.AccessControl.AccessControlSections includeSections)
    {
        this._wrapped.SetSecurityDescriptorSddlForm(sddlForm, includeSections);
    }
    
    public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm)
    {
        this._wrapped.SetSecurityDescriptorBinaryForm(binaryForm);
    }
    
    public virtual void SetSecurityDescriptorBinaryForm(byte[] binaryForm, System.Security.AccessControl.AccessControlSections includeSections)
    {
        this._wrapped.SetSecurityDescriptorBinaryForm(binaryForm, includeSections);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.ActiveDirectoryAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryAccessRule
{
    
    private System.DirectoryServices.ActiveDirectoryAccessRule _wrapped;
    
    public WrappedActiveDirectoryAccessRule(System.DirectoryServices.ActiveDirectoryAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IListChildrenAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.ListChildrenAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedListChildrenAccessRule
{
    
    private System.DirectoryServices.ListChildrenAccessRule _wrapped;
    
    public WrappedListChildrenAccessRule(System.DirectoryServices.ListChildrenAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ICreateChildAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.CreateChildAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedCreateChildAccessRule
{
    
    private System.DirectoryServices.CreateChildAccessRule _wrapped;
    
    public WrappedCreateChildAccessRule(System.DirectoryServices.CreateChildAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDeleteChildAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.DeleteChildAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDeleteChildAccessRule
{
    
    private System.DirectoryServices.DeleteChildAccessRule _wrapped;
    
    public WrappedDeleteChildAccessRule(System.DirectoryServices.DeleteChildAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IPropertyAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.PropertyAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedPropertyAccessRule
{
    
    private System.DirectoryServices.PropertyAccessRule _wrapped;
    
    public WrappedPropertyAccessRule(System.DirectoryServices.PropertyAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IPropertySetAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.PropertySetAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedPropertySetAccessRule
{
    
    private System.DirectoryServices.PropertySetAccessRule _wrapped;
    
    public WrappedPropertySetAccessRule(System.DirectoryServices.PropertySetAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IExtendedRightAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.ExtendedRightAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedExtendedRightAccessRule
{
    
    private System.DirectoryServices.ExtendedRightAccessRule _wrapped;
    
    public WrappedExtendedRightAccessRule(System.DirectoryServices.ExtendedRightAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDeleteTreeAccessRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AccessControlType AccessControlType {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.DeleteTreeAccessRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDeleteTreeAccessRule
{
    
    private System.DirectoryServices.DeleteTreeAccessRule _wrapped;
    
    public WrappedDeleteTreeAccessRule(System.DirectoryServices.DeleteTreeAccessRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AccessControlType AccessControlType
    {
        get
        {
            return this._wrapped.AccessControlType;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryAuditRule {
    
    System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType {
        get;
    }
    
    System.Guid ObjectType {
        get;
    }
    
    System.Guid InheritedObjectType {
        get;
    }
    
    System.Security.AccessControl.ObjectAceFlags ObjectFlags {
        get;
    }
    
    System.Security.AccessControl.AuditFlags AuditFlags {
        get;
    }
    
    System.Security.Principal.IdentityReference IdentityReference {
        get;
    }
    
    bool IsInherited {
        get;
    }
    
    System.Security.AccessControl.InheritanceFlags InheritanceFlags {
        get;
    }
    
    System.Security.AccessControl.PropagationFlags PropagationFlags {
        get;
    }
    
    System.DirectoryServices.ActiveDirectoryAuditRule Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryAuditRule
{
    
    private System.DirectoryServices.ActiveDirectoryAuditRule _wrapped;
    
    public WrappedActiveDirectoryAuditRule(System.DirectoryServices.ActiveDirectoryAuditRule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectoryRights ActiveDirectoryRights
    {
        get
        {
            return this._wrapped.ActiveDirectoryRights;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurityInheritance InheritanceType
    {
        get
        {
            return this._wrapped.InheritanceType;
        }
    }
    
    public virtual System.Guid ObjectType
    {
        get
        {
            return this._wrapped.ObjectType;
        }
    }
    
    public virtual System.Guid InheritedObjectType
    {
        get
        {
            return this._wrapped.InheritedObjectType;
        }
    }
    
    public virtual System.Security.AccessControl.ObjectAceFlags ObjectFlags
    {
        get
        {
            return this._wrapped.ObjectFlags;
        }
    }
    
    public virtual System.Security.AccessControl.AuditFlags AuditFlags
    {
        get
        {
            return this._wrapped.AuditFlags;
        }
    }
    
    public virtual System.Security.Principal.IdentityReference IdentityReference
    {
        get
        {
            return this._wrapped.IdentityReference;
        }
    }
    
    public virtual bool IsInherited
    {
        get
        {
            return this._wrapped.IsInherited;
        }
    }
    
    public virtual System.Security.AccessControl.InheritanceFlags InheritanceFlags
    {
        get
        {
            return this._wrapped.InheritanceFlags;
        }
    }
    
    public virtual System.Security.AccessControl.PropagationFlags PropagationFlags
    {
        get
        {
            return this._wrapped.PropagationFlags;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDSDescriptionAttribute {
    
    string Description {
        get;
    }
    
    object TypeId {
        get;
    }
    
    System.DirectoryServices.DSDescriptionAttribute Wrapped {
        get;
    }
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    bool IsDefaultAttribute();
    
    bool Match(object obj);
    
    string ToString();
    
    System.Type GetType();
}

public partial class WrappedDSDescriptionAttribute
{
    
    private System.DirectoryServices.DSDescriptionAttribute _wrapped;
    
    public WrappedDSDescriptionAttribute(System.DirectoryServices.DSDescriptionAttribute wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Description
    {
        get
        {
            return this._wrapped.Description;
        }
    }
    
    public virtual object TypeId
    {
        get
        {
            return this._wrapped.TypeId;
        }
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual bool IsDefaultAttribute()
    {
        return this._wrapped.IsDefaultAttribute();
    }
    
    public virtual bool Match(object obj)
    {
        return this._wrapped.Match(obj);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryEntries {
    
    System.DirectoryServices.SchemaNameCollection SchemaFilter {
        get;
    }
    
    System.DirectoryServices.DirectoryEntries Wrapped {
        get;
    }
    
    System.DirectoryServices.DirectoryEntry Add(string name, string schemaClassName);
    
    System.DirectoryServices.DirectoryEntry Find(string name);
    
    System.DirectoryServices.DirectoryEntry Find(string name, string schemaClassName);
    
    void Remove(System.DirectoryServices.DirectoryEntry entry);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryEntries
{
    
    private System.DirectoryServices.DirectoryEntries _wrapped;
    
    public WrappedDirectoryEntries(System.DirectoryServices.DirectoryEntries wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.SchemaNameCollection SchemaFilter
    {
        get
        {
            return this._wrapped.SchemaFilter;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntry Add(string name, string schemaClassName)
    {
        return this._wrapped.Add(name, schemaClassName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry Find(string name)
    {
        return this._wrapped.Find(name);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry Find(string name, string schemaClassName)
    {
        return this._wrapped.Find(name, schemaClassName);
    }
    
    public virtual void Remove(System.DirectoryServices.DirectoryEntry entry)
    {
        this._wrapped.Remove(entry);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryEntry {
    
    System.DirectoryServices.AuthenticationTypes AuthenticationType {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryEntries Children {
        get;
    }
    
    System.Guid Guid {
        get;
    }
    
    System.DirectoryServices.ActiveDirectorySecurity ObjectSecurity {
        get;
        set;
    }
    
    string Name {
        get;
    }
    
    string NativeGuid {
        get;
    }
    
    object NativeObject {
        get;
    }
    
    System.DirectoryServices.DirectoryEntry Parent {
        get;
    }
    
    string Password {
        set;
    }
    
    string Path {
        get;
        set;
    }
    
    System.DirectoryServices.PropertyCollection Properties {
        get;
    }
    
    string SchemaClassName {
        get;
    }
    
    System.DirectoryServices.DirectoryEntry SchemaEntry {
        get;
    }
    
    bool UsePropertyCache {
        get;
        set;
    }
    
    string Username {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryEntryConfiguration Options {
        get;
    }
    
    System.ComponentModel.ISite Site {
        get;
        set;
    }
    
    System.ComponentModel.IContainer Container {
        get;
    }
    
    System.DirectoryServices.DirectoryEntry Wrapped {
        get;
    }
    
    void Close();
    
    void CommitChanges();
    
    System.DirectoryServices.DirectoryEntry CopyTo(System.DirectoryServices.DirectoryEntry newParent);
    
    System.DirectoryServices.DirectoryEntry CopyTo(System.DirectoryServices.DirectoryEntry newParent, string newName);
    
    void DeleteTree();
    
    object Invoke(string methodName, object[] args);
    
    object InvokeGet(string propertyName);
    
    void InvokeSet(string propertyName, object[] args);
    
    void MoveTo(System.DirectoryServices.DirectoryEntry newParent);
    
    void MoveTo(System.DirectoryServices.DirectoryEntry newParent, string newName);
    
    void RefreshCache();
    
    void RefreshCache(string[] propertyNames);
    
    void Rename(string newName);
    
    void Dispose();
    
    string ToString();
    
    object GetLifetimeService();
    
    object InitializeLifetimeService();
    
    System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType);
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryEntry
{
    
    private System.DirectoryServices.DirectoryEntry _wrapped;
    
    public WrappedDirectoryEntry(System.DirectoryServices.DirectoryEntry wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.AuthenticationTypes AuthenticationType
    {
        get
        {
            return this._wrapped.AuthenticationType;
        }
        set
        {
            this._wrapped.AuthenticationType = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntries Children
    {
        get
        {
            return this._wrapped.Children;
        }
    }
    
    public virtual System.Guid Guid
    {
        get
        {
            return this._wrapped.Guid;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurity ObjectSecurity
    {
        get
        {
            return this._wrapped.ObjectSecurity;
        }
        set
        {
            this._wrapped.ObjectSecurity = value;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string NativeGuid
    {
        get
        {
            return this._wrapped.NativeGuid;
        }
    }
    
    public virtual object NativeObject
    {
        get
        {
            return this._wrapped.NativeObject;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntry Parent
    {
        get
        {
            return this._wrapped.Parent;
        }
    }
    
    public virtual string Password
    {
        set
        {
            this._wrapped.Password = value;
        }
    }
    
    public virtual string Path
    {
        get
        {
            return this._wrapped.Path;
        }
        set
        {
            this._wrapped.Path = value;
        }
    }
    
    public virtual System.DirectoryServices.PropertyCollection Properties
    {
        get
        {
            return this._wrapped.Properties;
        }
    }
    
    public virtual string SchemaClassName
    {
        get
        {
            return this._wrapped.SchemaClassName;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntry SchemaEntry
    {
        get
        {
            return this._wrapped.SchemaEntry;
        }
    }
    
    public virtual bool UsePropertyCache
    {
        get
        {
            return this._wrapped.UsePropertyCache;
        }
        set
        {
            this._wrapped.UsePropertyCache = value;
        }
    }
    
    public virtual string Username
    {
        get
        {
            return this._wrapped.Username;
        }
        set
        {
            this._wrapped.Username = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntryConfiguration Options
    {
        get
        {
            return this._wrapped.Options;
        }
    }
    
    public virtual System.ComponentModel.ISite Site
    {
        get
        {
            return this._wrapped.Site;
        }
        set
        {
            this._wrapped.Site = value;
        }
    }
    
    public virtual System.ComponentModel.IContainer Container
    {
        get
        {
            return this._wrapped.Container;
        }
    }
    
    public virtual void Close()
    {
        this._wrapped.Close();
    }
    
    public virtual void CommitChanges()
    {
        this._wrapped.CommitChanges();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry CopyTo(System.DirectoryServices.DirectoryEntry newParent)
    {
        return this._wrapped.CopyTo(newParent);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry CopyTo(System.DirectoryServices.DirectoryEntry newParent, string newName)
    {
        return this._wrapped.CopyTo(newParent, newName);
    }
    
    public virtual void DeleteTree()
    {
        this._wrapped.DeleteTree();
    }
    
    public virtual object Invoke(string methodName, object[] args)
    {
        return this._wrapped.Invoke(methodName, args);
    }
    
    public virtual object InvokeGet(string propertyName)
    {
        return this._wrapped.InvokeGet(propertyName);
    }
    
    public virtual void InvokeSet(string propertyName, object[] args)
    {
        this._wrapped.InvokeSet(propertyName, args);
    }
    
    public virtual void MoveTo(System.DirectoryServices.DirectoryEntry newParent)
    {
        this._wrapped.MoveTo(newParent);
    }
    
    public virtual void MoveTo(System.DirectoryServices.DirectoryEntry newParent, string newName)
    {
        this._wrapped.MoveTo(newParent, newName);
    }
    
    public virtual void RefreshCache()
    {
        this._wrapped.RefreshCache();
    }
    
    public virtual void RefreshCache(string[] propertyNames)
    {
        this._wrapped.RefreshCache(propertyNames);
    }
    
    public virtual void Rename(string newName)
    {
        this._wrapped.Rename(newName);
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual object GetLifetimeService()
    {
        return this._wrapped.GetLifetimeService();
    }
    
    public virtual object InitializeLifetimeService()
    {
        return this._wrapped.InitializeLifetimeService();
    }
    
    public virtual System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
    {
        return this._wrapped.CreateObjRef(requestedType);
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryEntryConfiguration {
    
    System.DirectoryServices.ReferralChasingOption Referral {
        get;
        set;
    }
    
    System.DirectoryServices.SecurityMasks SecurityMasks {
        get;
        set;
    }
    
    int PageSize {
        get;
        set;
    }
    
    int PasswordPort {
        get;
        set;
    }
    
    System.DirectoryServices.PasswordEncodingMethod PasswordEncoding {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryEntryConfiguration Wrapped {
        get;
    }
    
    string GetCurrentServerName();
    
    bool IsMutuallyAuthenticated();
    
    void SetUserNameQueryQuota(string accountName);
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryEntryConfiguration
{
    
    private System.DirectoryServices.DirectoryEntryConfiguration _wrapped;
    
    public WrappedDirectoryEntryConfiguration(System.DirectoryServices.DirectoryEntryConfiguration wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ReferralChasingOption Referral
    {
        get
        {
            return this._wrapped.Referral;
        }
        set
        {
            this._wrapped.Referral = value;
        }
    }
    
    public virtual System.DirectoryServices.SecurityMasks SecurityMasks
    {
        get
        {
            return this._wrapped.SecurityMasks;
        }
        set
        {
            this._wrapped.SecurityMasks = value;
        }
    }
    
    public virtual int PageSize
    {
        get
        {
            return this._wrapped.PageSize;
        }
        set
        {
            this._wrapped.PageSize = value;
        }
    }
    
    public virtual int PasswordPort
    {
        get
        {
            return this._wrapped.PasswordPort;
        }
        set
        {
            this._wrapped.PasswordPort = value;
        }
    }
    
    public virtual System.DirectoryServices.PasswordEncodingMethod PasswordEncoding
    {
        get
        {
            return this._wrapped.PasswordEncoding;
        }
        set
        {
            this._wrapped.PasswordEncoding = value;
        }
    }
    
    public virtual string GetCurrentServerName()
    {
        return this._wrapped.GetCurrentServerName();
    }
    
    public virtual bool IsMutuallyAuthenticated()
    {
        return this._wrapped.IsMutuallyAuthenticated();
    }
    
    public virtual void SetUserNameQueryQuota(string accountName)
    {
        this._wrapped.SetUserNameQueryQuota(accountName);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectorySearcher {
    
    bool CacheResults {
        get;
        set;
    }
    
    System.TimeSpan ClientTimeout {
        get;
        set;
    }
    
    bool PropertyNamesOnly {
        get;
        set;
    }
    
    string Filter {
        get;
        set;
    }
    
    int PageSize {
        get;
        set;
    }
    
    System.Collections.Specialized.StringCollection PropertiesToLoad {
        get;
    }
    
    System.DirectoryServices.ReferralChasingOption ReferralChasing {
        get;
        set;
    }
    
    System.DirectoryServices.SearchScope SearchScope {
        get;
        set;
    }
    
    System.TimeSpan ServerPageTimeLimit {
        get;
        set;
    }
    
    System.TimeSpan ServerTimeLimit {
        get;
        set;
    }
    
    int SizeLimit {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryEntry SearchRoot {
        get;
        set;
    }
    
    System.DirectoryServices.SortOption Sort {
        get;
        set;
    }
    
    bool Asynchronous {
        get;
        set;
    }
    
    bool Tombstone {
        get;
        set;
    }
    
    string AttributeScopeQuery {
        get;
        set;
    }
    
    System.DirectoryServices.DereferenceAlias DerefAlias {
        get;
        set;
    }
    
    System.DirectoryServices.SecurityMasks SecurityMasks {
        get;
        set;
    }
    
    System.DirectoryServices.ExtendedDN ExtendedDN {
        get;
        set;
    }
    
    System.DirectoryServices.DirectorySynchronization DirectorySynchronization {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryVirtualListView VirtualListView {
        get;
        set;
    }
    
    System.ComponentModel.ISite Site {
        get;
        set;
    }
    
    System.ComponentModel.IContainer Container {
        get;
    }
    
    System.DirectoryServices.DirectorySearcher Wrapped {
        get;
    }
    
    System.DirectoryServices.SearchResult FindOne();
    
    System.DirectoryServices.SearchResultCollection FindAll();
    
    void Dispose();
    
    string ToString();
    
    object GetLifetimeService();
    
    object InitializeLifetimeService();
    
    System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType);
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectorySearcher
{
    
    private System.DirectoryServices.DirectorySearcher _wrapped;
    
    public WrappedDirectorySearcher(System.DirectoryServices.DirectorySearcher wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual bool CacheResults
    {
        get
        {
            return this._wrapped.CacheResults;
        }
        set
        {
            this._wrapped.CacheResults = value;
        }
    }
    
    public virtual System.TimeSpan ClientTimeout
    {
        get
        {
            return this._wrapped.ClientTimeout;
        }
        set
        {
            this._wrapped.ClientTimeout = value;
        }
    }
    
    public virtual bool PropertyNamesOnly
    {
        get
        {
            return this._wrapped.PropertyNamesOnly;
        }
        set
        {
            this._wrapped.PropertyNamesOnly = value;
        }
    }
    
    public virtual string Filter
    {
        get
        {
            return this._wrapped.Filter;
        }
        set
        {
            this._wrapped.Filter = value;
        }
    }
    
    public virtual int PageSize
    {
        get
        {
            return this._wrapped.PageSize;
        }
        set
        {
            this._wrapped.PageSize = value;
        }
    }
    
    public virtual System.Collections.Specialized.StringCollection PropertiesToLoad
    {
        get
        {
            return this._wrapped.PropertiesToLoad;
        }
    }
    
    public virtual System.DirectoryServices.ReferralChasingOption ReferralChasing
    {
        get
        {
            return this._wrapped.ReferralChasing;
        }
        set
        {
            this._wrapped.ReferralChasing = value;
        }
    }
    
    public virtual System.DirectoryServices.SearchScope SearchScope
    {
        get
        {
            return this._wrapped.SearchScope;
        }
        set
        {
            this._wrapped.SearchScope = value;
        }
    }
    
    public virtual System.TimeSpan ServerPageTimeLimit
    {
        get
        {
            return this._wrapped.ServerPageTimeLimit;
        }
        set
        {
            this._wrapped.ServerPageTimeLimit = value;
        }
    }
    
    public virtual System.TimeSpan ServerTimeLimit
    {
        get
        {
            return this._wrapped.ServerTimeLimit;
        }
        set
        {
            this._wrapped.ServerTimeLimit = value;
        }
    }
    
    public virtual int SizeLimit
    {
        get
        {
            return this._wrapped.SizeLimit;
        }
        set
        {
            this._wrapped.SizeLimit = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntry SearchRoot
    {
        get
        {
            return this._wrapped.SearchRoot;
        }
        set
        {
            this._wrapped.SearchRoot = value;
        }
    }
    
    public virtual System.DirectoryServices.SortOption Sort
    {
        get
        {
            return this._wrapped.Sort;
        }
        set
        {
            this._wrapped.Sort = value;
        }
    }
    
    public virtual bool Asynchronous
    {
        get
        {
            return this._wrapped.Asynchronous;
        }
        set
        {
            this._wrapped.Asynchronous = value;
        }
    }
    
    public virtual bool Tombstone
    {
        get
        {
            return this._wrapped.Tombstone;
        }
        set
        {
            this._wrapped.Tombstone = value;
        }
    }
    
    public virtual string AttributeScopeQuery
    {
        get
        {
            return this._wrapped.AttributeScopeQuery;
        }
        set
        {
            this._wrapped.AttributeScopeQuery = value;
        }
    }
    
    public virtual System.DirectoryServices.DereferenceAlias DerefAlias
    {
        get
        {
            return this._wrapped.DerefAlias;
        }
        set
        {
            this._wrapped.DerefAlias = value;
        }
    }
    
    public virtual System.DirectoryServices.SecurityMasks SecurityMasks
    {
        get
        {
            return this._wrapped.SecurityMasks;
        }
        set
        {
            this._wrapped.SecurityMasks = value;
        }
    }
    
    public virtual System.DirectoryServices.ExtendedDN ExtendedDN
    {
        get
        {
            return this._wrapped.ExtendedDN;
        }
        set
        {
            this._wrapped.ExtendedDN = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectorySynchronization DirectorySynchronization
    {
        get
        {
            return this._wrapped.DirectorySynchronization;
        }
        set
        {
            this._wrapped.DirectorySynchronization = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryVirtualListView VirtualListView
    {
        get
        {
            return this._wrapped.VirtualListView;
        }
        set
        {
            this._wrapped.VirtualListView = value;
        }
    }
    
    public virtual System.ComponentModel.ISite Site
    {
        get
        {
            return this._wrapped.Site;
        }
        set
        {
            this._wrapped.Site = value;
        }
    }
    
    public virtual System.ComponentModel.IContainer Container
    {
        get
        {
            return this._wrapped.Container;
        }
    }
    
    public virtual System.DirectoryServices.SearchResult FindOne()
    {
        return this._wrapped.FindOne();
    }
    
    public virtual System.DirectoryServices.SearchResultCollection FindAll()
    {
        return this._wrapped.FindAll();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual object GetLifetimeService()
    {
        return this._wrapped.GetLifetimeService();
    }
    
    public virtual object InitializeLifetimeService()
    {
        return this._wrapped.InitializeLifetimeService();
    }
    
    public virtual System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
    {
        return this._wrapped.CreateObjRef(requestedType);
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServicesPermission {
    
    System.DirectoryServices.DirectoryServicesPermissionEntryCollection PermissionEntries {
        get;
    }
    
    System.DirectoryServices.DirectoryServicesPermission Wrapped {
        get;
    }
    
    System.Security.IPermission Copy();
    
    void FromXml(System.Security.SecurityElement securityElement);
    
    System.Security.IPermission Intersect(System.Security.IPermission target);
    
    bool IsSubsetOf(System.Security.IPermission target);
    
    bool IsUnrestricted();
    
    System.Security.SecurityElement ToXml();
    
    System.Security.IPermission Union(System.Security.IPermission target);
    
    void Demand();
    
    void Assert();
    
    void Deny();
    
    void PermitOnly();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServicesPermission
{
    
    private System.DirectoryServices.DirectoryServicesPermission _wrapped;
    
    public WrappedDirectoryServicesPermission(System.DirectoryServices.DirectoryServicesPermission wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.DirectoryServicesPermissionEntryCollection PermissionEntries
    {
        get
        {
            return this._wrapped.PermissionEntries;
        }
    }
    
    public virtual System.Security.IPermission Copy()
    {
        return this._wrapped.Copy();
    }
    
    public virtual void FromXml(System.Security.SecurityElement securityElement)
    {
        this._wrapped.FromXml(securityElement);
    }
    
    public virtual System.Security.IPermission Intersect(System.Security.IPermission target)
    {
        return this._wrapped.Intersect(target);
    }
    
    public virtual bool IsSubsetOf(System.Security.IPermission target)
    {
        return this._wrapped.IsSubsetOf(target);
    }
    
    public virtual bool IsUnrestricted()
    {
        return this._wrapped.IsUnrestricted();
    }
    
    public virtual System.Security.SecurityElement ToXml()
    {
        return this._wrapped.ToXml();
    }
    
    public virtual System.Security.IPermission Union(System.Security.IPermission target)
    {
        return this._wrapped.Union(target);
    }
    
    public virtual void Demand()
    {
        this._wrapped.Demand();
    }
    
    public virtual void Assert()
    {
        this._wrapped.Assert();
    }
    
    public virtual void Deny()
    {
        this._wrapped.Deny();
    }
    
    public virtual void PermitOnly()
    {
        this._wrapped.PermitOnly();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServicesPermissionAttribute {
    
    string Path {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryServicesPermissionAccess PermissionAccess {
        get;
        set;
    }
    
    System.Security.Permissions.SecurityAction Action {
        get;
        set;
    }
    
    bool Unrestricted {
        get;
        set;
    }
    
    object TypeId {
        get;
    }
    
    System.DirectoryServices.DirectoryServicesPermissionAttribute Wrapped {
        get;
    }
    
    System.Security.IPermission CreatePermission();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    bool Match(object obj);
    
    bool IsDefaultAttribute();
    
    string ToString();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServicesPermissionAttribute
{
    
    private System.DirectoryServices.DirectoryServicesPermissionAttribute _wrapped;
    
    public WrappedDirectoryServicesPermissionAttribute(System.DirectoryServices.DirectoryServicesPermissionAttribute wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Path
    {
        get
        {
            return this._wrapped.Path;
        }
        set
        {
            this._wrapped.Path = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryServicesPermissionAccess PermissionAccess
    {
        get
        {
            return this._wrapped.PermissionAccess;
        }
        set
        {
            this._wrapped.PermissionAccess = value;
        }
    }
    
    public virtual System.Security.Permissions.SecurityAction Action
    {
        get
        {
            return this._wrapped.Action;
        }
        set
        {
            this._wrapped.Action = value;
        }
    }
    
    public virtual bool Unrestricted
    {
        get
        {
            return this._wrapped.Unrestricted;
        }
        set
        {
            this._wrapped.Unrestricted = value;
        }
    }
    
    public virtual object TypeId
    {
        get
        {
            return this._wrapped.TypeId;
        }
    }
    
    public virtual System.Security.IPermission CreatePermission()
    {
        return this._wrapped.CreatePermission();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual bool Match(object obj)
    {
        return this._wrapped.Match(obj);
    }
    
    public virtual bool IsDefaultAttribute()
    {
        return this._wrapped.IsDefaultAttribute();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServicesPermissionEntry {
    
    string Path {
        get;
    }
    
    System.DirectoryServices.DirectoryServicesPermissionAccess PermissionAccess {
        get;
    }
    
    System.DirectoryServices.DirectoryServicesPermissionEntry Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServicesPermissionEntry
{
    
    private System.DirectoryServices.DirectoryServicesPermissionEntry _wrapped;
    
    public WrappedDirectoryServicesPermissionEntry(System.DirectoryServices.DirectoryServicesPermissionEntry wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Path
    {
        get
        {
            return this._wrapped.Path;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryServicesPermissionAccess PermissionAccess
    {
        get
        {
            return this._wrapped.PermissionAccess;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServicesPermissionEntryCollection {
    
    System.DirectoryServices.DirectoryServicesPermissionEntry Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.DirectoryServicesPermissionEntryCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.DirectoryServicesPermissionEntry value);
    
    void AddRange(System.DirectoryServices.DirectoryServicesPermissionEntry[] value);
    
    void AddRange(System.DirectoryServices.DirectoryServicesPermissionEntryCollection value);
    
    bool Contains(System.DirectoryServices.DirectoryServicesPermissionEntry value);
    
    void CopyTo(System.DirectoryServices.DirectoryServicesPermissionEntry[] array, int index);
    
    int IndexOf(System.DirectoryServices.DirectoryServicesPermissionEntry value);
    
    void Insert(int index, System.DirectoryServices.DirectoryServicesPermissionEntry value);
    
    void Remove(System.DirectoryServices.DirectoryServicesPermissionEntry value);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServicesPermissionEntryCollection
{
    
    private System.DirectoryServices.DirectoryServicesPermissionEntryCollection _wrapped;
    
    public WrappedDirectoryServicesPermissionEntryCollection(System.DirectoryServices.DirectoryServicesPermissionEntryCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.DirectoryServicesPermissionEntry Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.DirectoryServicesPermissionEntry value)
    {
        return this._wrapped.Add(value);
    }
    
    public virtual void AddRange(System.DirectoryServices.DirectoryServicesPermissionEntry[] value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual void AddRange(System.DirectoryServices.DirectoryServicesPermissionEntryCollection value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual bool Contains(System.DirectoryServices.DirectoryServicesPermissionEntry value)
    {
        return this._wrapped.Contains(value);
    }
    
    public virtual void CopyTo(System.DirectoryServices.DirectoryServicesPermissionEntry[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.DirectoryServicesPermissionEntry value)
    {
        return this._wrapped.IndexOf(value);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.DirectoryServicesPermissionEntry value)
    {
        this._wrapped.Insert(index, value);
    }
    
    public virtual void Remove(System.DirectoryServices.DirectoryServicesPermissionEntry value)
    {
        this._wrapped.Remove(value);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectorySynchronization {
    
    System.DirectoryServices.DirectorySynchronizationOptions Option {
        get;
        set;
    }
    
    System.DirectoryServices.DirectorySynchronization Wrapped {
        get;
    }
    
    byte[] GetDirectorySynchronizationCookie();
    
    void ResetDirectorySynchronizationCookie();
    
    void ResetDirectorySynchronizationCookie(byte[] cookie);
    
    System.DirectoryServices.DirectorySynchronization Copy();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectorySynchronization
{
    
    private System.DirectoryServices.DirectorySynchronization _wrapped;
    
    public WrappedDirectorySynchronization(System.DirectoryServices.DirectorySynchronization wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.DirectorySynchronizationOptions Option
    {
        get
        {
            return this._wrapped.Option;
        }
        set
        {
            this._wrapped.Option = value;
        }
    }
    
    public virtual byte[] GetDirectorySynchronizationCookie()
    {
        return this._wrapped.GetDirectorySynchronizationCookie();
    }
    
    public virtual void ResetDirectorySynchronizationCookie()
    {
        this._wrapped.ResetDirectorySynchronizationCookie();
    }
    
    public virtual void ResetDirectorySynchronizationCookie(byte[] cookie)
    {
        this._wrapped.ResetDirectorySynchronizationCookie(cookie);
    }
    
    public virtual System.DirectoryServices.DirectorySynchronization Copy()
    {
        return this._wrapped.Copy();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryVirtualListView {
    
    int BeforeCount {
        get;
        set;
    }
    
    int AfterCount {
        get;
        set;
    }
    
    int Offset {
        get;
        set;
    }
    
    int TargetPercentage {
        get;
        set;
    }
    
    string Target {
        get;
        set;
    }
    
    int ApproximateTotal {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryVirtualListViewContext DirectoryVirtualListViewContext {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryVirtualListView Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryVirtualListView
{
    
    private System.DirectoryServices.DirectoryVirtualListView _wrapped;
    
    public WrappedDirectoryVirtualListView(System.DirectoryServices.DirectoryVirtualListView wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual int BeforeCount
    {
        get
        {
            return this._wrapped.BeforeCount;
        }
        set
        {
            this._wrapped.BeforeCount = value;
        }
    }
    
    public virtual int AfterCount
    {
        get
        {
            return this._wrapped.AfterCount;
        }
        set
        {
            this._wrapped.AfterCount = value;
        }
    }
    
    public virtual int Offset
    {
        get
        {
            return this._wrapped.Offset;
        }
        set
        {
            this._wrapped.Offset = value;
        }
    }
    
    public virtual int TargetPercentage
    {
        get
        {
            return this._wrapped.TargetPercentage;
        }
        set
        {
            this._wrapped.TargetPercentage = value;
        }
    }
    
    public virtual string Target
    {
        get
        {
            return this._wrapped.Target;
        }
        set
        {
            this._wrapped.Target = value;
        }
    }
    
    public virtual int ApproximateTotal
    {
        get
        {
            return this._wrapped.ApproximateTotal;
        }
        set
        {
            this._wrapped.ApproximateTotal = value;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryVirtualListViewContext DirectoryVirtualListViewContext
    {
        get
        {
            return this._wrapped.DirectoryVirtualListViewContext;
        }
        set
        {
            this._wrapped.DirectoryVirtualListViewContext = value;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryVirtualListViewContext {
    
    System.DirectoryServices.DirectoryVirtualListViewContext Wrapped {
        get;
    }
    
    System.DirectoryServices.DirectoryVirtualListViewContext Copy();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryVirtualListViewContext
{
    
    private System.DirectoryServices.DirectoryVirtualListViewContext _wrapped;
    
    public WrappedDirectoryVirtualListViewContext(System.DirectoryServices.DirectoryVirtualListViewContext wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.DirectoryVirtualListViewContext Copy()
    {
        return this._wrapped.Copy();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IPropertyCollection {
    
    System.DirectoryServices.PropertyValueCollection Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.Collections.ICollection PropertyNames {
        get;
    }
    
    System.Collections.ICollection Values {
        get;
    }
    
    System.DirectoryServices.PropertyCollection Wrapped {
        get;
    }
    
    bool Contains(string propertyName);
    
    void CopyTo(System.DirectoryServices.PropertyValueCollection[] array, int index);
    
    System.Collections.IDictionaryEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedPropertyCollection
{
    
    private System.DirectoryServices.PropertyCollection _wrapped;
    
    public WrappedPropertyCollection(System.DirectoryServices.PropertyCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.PropertyValueCollection Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual System.Collections.ICollection PropertyNames
    {
        get
        {
            return this._wrapped.PropertyNames;
        }
    }
    
    public virtual System.Collections.ICollection Values
    {
        get
        {
            return this._wrapped.Values;
        }
    }
    
    public virtual bool Contains(string propertyName)
    {
        return this._wrapped.Contains(propertyName);
    }
    
    public virtual void CopyTo(System.DirectoryServices.PropertyValueCollection[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual System.Collections.IDictionaryEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IPropertyValueCollection {
    
    object Item {
        get;
        set;
    }
    
    string PropertyName {
        get;
    }
    
    object Value {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.PropertyValueCollection Wrapped {
        get;
    }
    
    int Add(object value);
    
    void AddRange(object[] value);
    
    void AddRange(System.DirectoryServices.PropertyValueCollection value);
    
    bool Contains(object value);
    
    void CopyTo(object[] array, int index);
    
    int IndexOf(object value);
    
    void Insert(int index, object value);
    
    void Remove(object value);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedPropertyValueCollection
{
    
    private System.DirectoryServices.PropertyValueCollection _wrapped;
    
    public WrappedPropertyValueCollection(System.DirectoryServices.PropertyValueCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual object Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual string PropertyName
    {
        get
        {
            return this._wrapped.PropertyName;
        }
    }
    
    public virtual object Value
    {
        get
        {
            return this._wrapped.Value;
        }
        set
        {
            this._wrapped.Value = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(object value)
    {
        return this._wrapped.Add(value);
    }
    
    public virtual void AddRange(object[] value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual void AddRange(System.DirectoryServices.PropertyValueCollection value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual bool Contains(object value)
    {
        return this._wrapped.Contains(value);
    }
    
    public virtual void CopyTo(object[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(object value)
    {
        return this._wrapped.IndexOf(value);
    }
    
    public virtual void Insert(int index, object value)
    {
        this._wrapped.Insert(index, value);
    }
    
    public virtual void Remove(object value)
    {
        this._wrapped.Remove(value);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IResultPropertyCollection {
    
    System.DirectoryServices.ResultPropertyValueCollection Item {
        get;
    }
    
    System.Collections.ICollection PropertyNames {
        get;
    }
    
    System.Collections.ICollection Values {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ResultPropertyCollection Wrapped {
        get;
    }
    
    bool Contains(string propertyName);
    
    void CopyTo(System.DirectoryServices.ResultPropertyValueCollection[] array, int index);
    
    void CopyTo(System.Array array, int index);
    
    void Clear();
    
    System.Collections.IDictionaryEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedResultPropertyCollection
{
    
    private System.DirectoryServices.ResultPropertyCollection _wrapped;
    
    public WrappedResultPropertyCollection(System.DirectoryServices.ResultPropertyCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ResultPropertyValueCollection Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual System.Collections.ICollection PropertyNames
    {
        get
        {
            return this._wrapped.PropertyNames;
        }
    }
    
    public virtual System.Collections.ICollection Values
    {
        get
        {
            return this._wrapped.Values;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(string propertyName)
    {
        return this._wrapped.Contains(propertyName);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ResultPropertyValueCollection[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual void CopyTo(System.Array array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual System.Collections.IDictionaryEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IResultPropertyValueCollection {
    
    object Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ResultPropertyValueCollection Wrapped {
        get;
    }
    
    bool Contains(object value);
    
    int IndexOf(object value);
    
    void CopyTo(object[] values, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedResultPropertyValueCollection
{
    
    private System.DirectoryServices.ResultPropertyValueCollection _wrapped;
    
    public WrappedResultPropertyValueCollection(System.DirectoryServices.ResultPropertyValueCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual object Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(object value)
    {
        return this._wrapped.Contains(value);
    }
    
    public virtual int IndexOf(object value)
    {
        return this._wrapped.IndexOf(value);
    }
    
    public virtual void CopyTo(object[] values, int index)
    {
        this._wrapped.CopyTo(values, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISchemaNameCollection {
    
    string Item {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.SchemaNameCollection Wrapped {
        get;
    }
    
    int Add(string value);
    
    void AddRange(string[] value);
    
    void AddRange(System.DirectoryServices.SchemaNameCollection value);
    
    void Clear();
    
    bool Contains(string value);
    
    void CopyTo(string[] stringArray, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    int IndexOf(string value);
    
    void Insert(int index, string value);
    
    void Remove(string value);
    
    void RemoveAt(int index);
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSchemaNameCollection
{
    
    private System.DirectoryServices.SchemaNameCollection _wrapped;
    
    public WrappedSchemaNameCollection(System.DirectoryServices.SchemaNameCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(string value)
    {
        return this._wrapped.Add(value);
    }
    
    public virtual void AddRange(string[] value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual void AddRange(System.DirectoryServices.SchemaNameCollection value)
    {
        this._wrapped.AddRange(value);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual bool Contains(string value)
    {
        return this._wrapped.Contains(value);
    }
    
    public virtual void CopyTo(string[] stringArray, int index)
    {
        this._wrapped.CopyTo(stringArray, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual int IndexOf(string value)
    {
        return this._wrapped.IndexOf(value);
    }
    
    public virtual void Insert(int index, string value)
    {
        this._wrapped.Insert(index, value);
    }
    
    public virtual void Remove(string value)
    {
        this._wrapped.Remove(value);
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISearchResult {
    
    string Path {
        get;
    }
    
    System.DirectoryServices.ResultPropertyCollection Properties {
        get;
    }
    
    System.DirectoryServices.SearchResult Wrapped {
        get;
    }
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSearchResult
{
    
    private System.DirectoryServices.SearchResult _wrapped;
    
    public WrappedSearchResult(System.DirectoryServices.SearchResult wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Path
    {
        get
        {
            return this._wrapped.Path;
        }
    }
    
    public virtual System.DirectoryServices.ResultPropertyCollection Properties
    {
        get
        {
            return this._wrapped.Properties;
        }
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISearchResultCollection {
    
    System.DirectoryServices.SearchResult Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.IntPtr Handle {
        get;
    }
    
    string[] PropertiesLoaded {
        get;
    }
    
    System.DirectoryServices.SearchResultCollection Wrapped {
        get;
    }
    
    void Dispose();
    
    System.Collections.IEnumerator GetEnumerator();
    
    bool Contains(System.DirectoryServices.SearchResult result);
    
    void CopyTo(System.DirectoryServices.SearchResult[] results, int index);
    
    int IndexOf(System.DirectoryServices.SearchResult result);
    
    object GetLifetimeService();
    
    object InitializeLifetimeService();
    
    System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType);
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSearchResultCollection
{
    
    private System.DirectoryServices.SearchResultCollection _wrapped;
    
    public WrappedSearchResultCollection(System.DirectoryServices.SearchResultCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.SearchResult Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual System.IntPtr Handle
    {
        get
        {
            return this._wrapped.Handle;
        }
    }
    
    public virtual string[] PropertiesLoaded
    {
        get
        {
            return this._wrapped.PropertiesLoaded;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual bool Contains(System.DirectoryServices.SearchResult result)
    {
        return this._wrapped.Contains(result);
    }
    
    public virtual void CopyTo(System.DirectoryServices.SearchResult[] results, int index)
    {
        this._wrapped.CopyTo(results, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.SearchResult result)
    {
        return this._wrapped.IndexOf(result);
    }
    
    public virtual object GetLifetimeService()
    {
        return this._wrapped.GetLifetimeService();
    }
    
    public virtual object InitializeLifetimeService()
    {
        return this._wrapped.InitializeLifetimeService();
    }
    
    public virtual System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
    {
        return this._wrapped.CreateObjRef(requestedType);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISortOption {
    
    string PropertyName {
        get;
        set;
    }
    
    System.DirectoryServices.SortDirection Direction {
        get;
        set;
    }
    
    System.DirectoryServices.SortOption Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSortOption
{
    
    private System.DirectoryServices.SortOption _wrapped;
    
    public WrappedSortOption(System.DirectoryServices.SortOption wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string PropertyName
    {
        get
        {
            return this._wrapped.PropertyName;
        }
        set
        {
            this._wrapped.PropertyName = value;
        }
    }
    
    public virtual System.DirectoryServices.SortDirection Direction
    {
        get
        {
            return this._wrapped.Direction;
        }
        set
        {
            this._wrapped.Direction = value;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServicesCOMException {
    
    int ExtendedError {
        get;
    }
    
    string ExtendedErrorMessage {
        get;
    }
    
    int ErrorCode {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.DirectoryServicesCOMException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    string ToString();
    
    System.Exception GetBaseException();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServicesCOMException
{
    
    private System.DirectoryServices.DirectoryServicesCOMException _wrapped;
    
    public WrappedDirectoryServicesCOMException(System.DirectoryServices.DirectoryServicesCOMException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual int ExtendedError
    {
        get
        {
            return this._wrapped.ExtendedError;
        }
    }
    
    public virtual string ExtendedErrorMessage
    {
        get
        {
            return this._wrapped.ExtendedErrorMessage;
        }
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryReplicationMetadata {
    
    System.DirectoryServices.ActiveDirectory.AttributeMetadata Item {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection AttributeNames {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AttributeMetadataCollection Values {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata Wrapped {
        get;
    }
    
    bool Contains(string attributeName);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.AttributeMetadata[] array, int index);
    
    void CopyTo(System.Array array, int index);
    
    void Clear();
    
    System.Collections.IDictionaryEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryReplicationMetadata
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata _wrapped;
    
    public WrappedActiveDirectoryReplicationMetadata(System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AttributeMetadata Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection AttributeNames
    {
        get
        {
            return this._wrapped.AttributeNames;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AttributeMetadataCollection Values
    {
        get
        {
            return this._wrapped.Values;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(string attributeName)
    {
        return this._wrapped.Contains(attributeName);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.AttributeMetadata[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual void CopyTo(System.Array array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual System.Collections.IDictionaryEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchedule {
    
    bool[,,] RawSchedule {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule Wrapped {
        get;
    }
    
    void SetSchedule(System.DayOfWeek day, System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute);
    
    void SetSchedule(System.DayOfWeek[] days, System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute);
    
    void SetDailySchedule(System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute);
    
    void ResetSchedule();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchedule
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule _wrapped;
    
    public WrappedActiveDirectorySchedule(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual bool[,,] RawSchedule
    {
        get
        {
            return this._wrapped.RawSchedule;
        }
        set
        {
            this._wrapped.RawSchedule = value;
        }
    }
    
    public virtual void SetSchedule(System.DayOfWeek day, System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute)
    {
        this._wrapped.SetSchedule(day, fromHour, fromMinute, toHour, toMinute);
    }
    
    public virtual void SetSchedule(System.DayOfWeek[] days, System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute)
    {
        this._wrapped.SetSchedule(days, fromHour, fromMinute, toHour, toMinute);
    }
    
    public virtual void SetDailySchedule(System.DirectoryServices.ActiveDirectory.HourOfDay fromHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour fromMinute, System.DirectoryServices.ActiveDirectory.HourOfDay toHour, System.DirectoryServices.ActiveDirectory.MinuteOfHour toMinute)
    {
        this._wrapped.SetDailySchedule(fromHour, fromMinute, toHour, toMinute);
    }
    
    public virtual void ResetSchedule()
    {
        this._wrapped.ResetSchedule();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchema {
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer SchemaRoleOwner {
        get;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema Wrapped {
        get;
    }
    
    void RefreshSchema();
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass FindClass(string ldapDisplayName);
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass FindDefunctClass(string commonName);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllClasses();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllClasses(System.DirectoryServices.ActiveDirectory.SchemaClassType type);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllDefunctClasses();
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty FindProperty(string ldapDisplayName);
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty FindDefunctProperty(string commonName);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties(System.DirectoryServices.ActiveDirectory.PropertyTypes type);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllDefunctProperties();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchema
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema _wrapped;
    
    public WrappedActiveDirectorySchema(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer SchemaRoleOwner
    {
        get
        {
            return this._wrapped.SchemaRoleOwner;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual void RefreshSchema()
    {
        this._wrapped.RefreshSchema();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass FindClass(string ldapDisplayName)
    {
        return this._wrapped.FindClass(ldapDisplayName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass FindDefunctClass(string commonName)
    {
        return this._wrapped.FindDefunctClass(commonName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllClasses()
    {
        return this._wrapped.FindAllClasses();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllClasses(System.DirectoryServices.ActiveDirectory.SchemaClassType type)
    {
        return this._wrapped.FindAllClasses(type);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection FindAllDefunctClasses()
    {
        return this._wrapped.FindAllDefunctClasses();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty FindProperty(string ldapDisplayName)
    {
        return this._wrapped.FindProperty(ldapDisplayName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty FindDefunctProperty(string commonName)
    {
        return this._wrapped.FindDefunctProperty(commonName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties()
    {
        return this._wrapped.FindAllProperties();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties(System.DirectoryServices.ActiveDirectory.PropertyTypes type)
    {
        return this._wrapped.FindAllProperties(type);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllDefunctProperties()
    {
        return this._wrapped.FindAllDefunctProperties();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchemaClass {
    
    string Name {
        get;
    }
    
    string CommonName {
        get;
        set;
    }
    
    string Oid {
        get;
        set;
    }
    
    string Description {
        get;
        set;
    }
    
    bool IsDefunct {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection PossibleSuperiors {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection PossibleInferiors {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection MandatoryProperties {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection OptionalProperties {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection AuxiliaryClasses {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass SubClassOf {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.SchemaClassType Type {
        get;
        set;
    }
    
    System.Guid SchemaGuid {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectorySecurity DefaultObjectSecurityDescriptor {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass Wrapped {
        get;
    }
    
    void Dispose();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection GetAllProperties();
    
    void Save();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchemaClass
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass _wrapped;
    
    public WrappedActiveDirectorySchemaClass(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string CommonName
    {
        get
        {
            return this._wrapped.CommonName;
        }
        set
        {
            this._wrapped.CommonName = value;
        }
    }
    
    public virtual string Oid
    {
        get
        {
            return this._wrapped.Oid;
        }
        set
        {
            this._wrapped.Oid = value;
        }
    }
    
    public virtual string Description
    {
        get
        {
            return this._wrapped.Description;
        }
        set
        {
            this._wrapped.Description = value;
        }
    }
    
    public virtual bool IsDefunct
    {
        get
        {
            return this._wrapped.IsDefunct;
        }
        set
        {
            this._wrapped.IsDefunct = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection PossibleSuperiors
    {
        get
        {
            return this._wrapped.PossibleSuperiors;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection PossibleInferiors
    {
        get
        {
            return this._wrapped.PossibleInferiors;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection MandatoryProperties
    {
        get
        {
            return this._wrapped.MandatoryProperties;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection OptionalProperties
    {
        get
        {
            return this._wrapped.OptionalProperties;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection AuxiliaryClasses
    {
        get
        {
            return this._wrapped.AuxiliaryClasses;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass SubClassOf
    {
        get
        {
            return this._wrapped.SubClassOf;
        }
        set
        {
            this._wrapped.SubClassOf = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SchemaClassType Type
    {
        get
        {
            return this._wrapped.Type;
        }
        set
        {
            this._wrapped.Type = value;
        }
    }
    
    public virtual System.Guid SchemaGuid
    {
        get
        {
            return this._wrapped.SchemaGuid;
        }
        set
        {
            this._wrapped.SchemaGuid = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectorySecurity DefaultObjectSecurityDescriptor
    {
        get
        {
            return this._wrapped.DefaultObjectSecurityDescriptor;
        }
        set
        {
            this._wrapped.DefaultObjectSecurityDescriptor = value;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection GetAllProperties()
    {
        return this._wrapped.GetAllProperties();
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchemaClassCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] schemaClasses);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection schemaClasses);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection schemaClasses);
    
    void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] schemaClasses, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchemaClassCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection _wrapped;
    
    public WrappedActiveDirectorySchemaClassCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        return this._wrapped.Add(schemaClass);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] schemaClasses)
    {
        this._wrapped.AddRange(schemaClasses);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClassCollection schemaClasses)
    {
        this._wrapped.AddRange(schemaClasses);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection schemaClasses)
    {
        this._wrapped.AddRange(schemaClasses);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        this._wrapped.Remove(schemaClass);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        this._wrapped.Insert(index, schemaClass);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        return this._wrapped.Contains(schemaClass);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] schemaClasses, int index)
    {
        this._wrapped.CopyTo(schemaClasses, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        return this._wrapped.IndexOf(schemaClass);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchemaProperty {
    
    string Name {
        get;
    }
    
    string CommonName {
        get;
        set;
    }
    
    string Oid {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySyntax Syntax {
        get;
        set;
    }
    
    string Description {
        get;
        set;
    }
    
    bool IsSingleValued {
        get;
        set;
    }
    
    bool IsIndexed {
        get;
        set;
    }
    
    bool IsIndexedOverContainer {
        get;
        set;
    }
    
    bool IsInAnr {
        get;
        set;
    }
    
    bool IsOnTombstonedObject {
        get;
        set;
    }
    
    bool IsTupleIndexed {
        get;
        set;
    }
    
    bool IsInGlobalCatalog {
        get;
        set;
    }
    
    System.Nullable<int> RangeLower {
        get;
        set;
    }
    
    System.Nullable<int> RangeUpper {
        get;
        set;
    }
    
    bool IsDefunct {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Link {
        get;
    }
    
    System.Nullable<int> LinkId {
        get;
        set;
    }
    
    System.Guid SchemaGuid {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Wrapped {
        get;
    }
    
    void Dispose();
    
    void Save();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchemaProperty
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty _wrapped;
    
    public WrappedActiveDirectorySchemaProperty(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string CommonName
    {
        get
        {
            return this._wrapped.CommonName;
        }
        set
        {
            this._wrapped.CommonName = value;
        }
    }
    
    public virtual string Oid
    {
        get
        {
            return this._wrapped.Oid;
        }
        set
        {
            this._wrapped.Oid = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySyntax Syntax
    {
        get
        {
            return this._wrapped.Syntax;
        }
        set
        {
            this._wrapped.Syntax = value;
        }
    }
    
    public virtual string Description
    {
        get
        {
            return this._wrapped.Description;
        }
        set
        {
            this._wrapped.Description = value;
        }
    }
    
    public virtual bool IsSingleValued
    {
        get
        {
            return this._wrapped.IsSingleValued;
        }
        set
        {
            this._wrapped.IsSingleValued = value;
        }
    }
    
    public virtual bool IsIndexed
    {
        get
        {
            return this._wrapped.IsIndexed;
        }
        set
        {
            this._wrapped.IsIndexed = value;
        }
    }
    
    public virtual bool IsIndexedOverContainer
    {
        get
        {
            return this._wrapped.IsIndexedOverContainer;
        }
        set
        {
            this._wrapped.IsIndexedOverContainer = value;
        }
    }
    
    public virtual bool IsInAnr
    {
        get
        {
            return this._wrapped.IsInAnr;
        }
        set
        {
            this._wrapped.IsInAnr = value;
        }
    }
    
    public virtual bool IsOnTombstonedObject
    {
        get
        {
            return this._wrapped.IsOnTombstonedObject;
        }
        set
        {
            this._wrapped.IsOnTombstonedObject = value;
        }
    }
    
    public virtual bool IsTupleIndexed
    {
        get
        {
            return this._wrapped.IsTupleIndexed;
        }
        set
        {
            this._wrapped.IsTupleIndexed = value;
        }
    }
    
    public virtual bool IsInGlobalCatalog
    {
        get
        {
            return this._wrapped.IsInGlobalCatalog;
        }
        set
        {
            this._wrapped.IsInGlobalCatalog = value;
        }
    }
    
    public virtual System.Nullable<int> RangeLower
    {
        get
        {
            return this._wrapped.RangeLower;
        }
        set
        {
            this._wrapped.RangeLower = value;
        }
    }
    
    public virtual System.Nullable<int> RangeUpper
    {
        get
        {
            return this._wrapped.RangeUpper;
        }
        set
        {
            this._wrapped.RangeUpper = value;
        }
    }
    
    public virtual bool IsDefunct
    {
        get
        {
            return this._wrapped.IsDefunct;
        }
        set
        {
            this._wrapped.IsDefunct = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Link
    {
        get
        {
            return this._wrapped.Link;
        }
    }
    
    public virtual System.Nullable<int> LinkId
    {
        get
        {
            return this._wrapped.LinkId;
        }
        set
        {
            this._wrapped.LinkId = value;
        }
    }
    
    public virtual System.Guid SchemaGuid
    {
        get
        {
            return this._wrapped.SchemaGuid;
        }
        set
        {
            this._wrapped.SchemaGuid = value;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySchemaPropertyCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection properties);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection properties);
    
    void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySchemaPropertyCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection _wrapped;
    
    public WrappedActiveDirectorySchemaPropertyCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        return this._wrapped.Add(schemaProperty);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties)
    {
        this._wrapped.AddRange(properties);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaPropertyCollection properties)
    {
        this._wrapped.AddRange(properties);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection properties)
    {
        this._wrapped.AddRange(properties);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        this._wrapped.Remove(schemaProperty);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        this._wrapped.Insert(index, schemaProperty);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        return this._wrapped.Contains(schemaProperty);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties, int index)
    {
        this._wrapped.CopyTo(properties, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        return this._wrapped.IndexOf(schemaProperty);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySite {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainCollection Domains {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection Subnets {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection Servers {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection AdjacentSites {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection SiteLinks {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer InterSiteTopologyGenerator {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteOptions Options {
        get;
        set;
    }
    
    string Location {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection BridgeheadServers {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryServerCollection PreferredSmtpBridgeheadServers {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryServerCollection PreferredRpcBridgeheadServers {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule IntraSiteReplicationSchedule {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Wrapped {
        get;
    }
    
    void Save();
    
    void Delete();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySite
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySite _wrapped;
    
    public WrappedActiveDirectorySite(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainCollection Domains
    {
        get
        {
            return this._wrapped.Domains;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection Subnets
    {
        get
        {
            return this._wrapped.Subnets;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection Servers
    {
        get
        {
            return this._wrapped.Servers;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection AdjacentSites
    {
        get
        {
            return this._wrapped.AdjacentSites;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection SiteLinks
    {
        get
        {
            return this._wrapped.SiteLinks;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer InterSiteTopologyGenerator
    {
        get
        {
            return this._wrapped.InterSiteTopologyGenerator;
        }
        set
        {
            this._wrapped.InterSiteTopologyGenerator = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteOptions Options
    {
        get
        {
            return this._wrapped.Options;
        }
        set
        {
            this._wrapped.Options = value;
        }
    }
    
    public virtual string Location
    {
        get
        {
            return this._wrapped.Location;
        }
        set
        {
            this._wrapped.Location = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection BridgeheadServers
    {
        get
        {
            return this._wrapped.BridgeheadServers;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServerCollection PreferredSmtpBridgeheadServers
    {
        get
        {
            return this._wrapped.PreferredSmtpBridgeheadServers;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServerCollection PreferredRpcBridgeheadServers
    {
        get
        {
            return this._wrapped.PreferredRpcBridgeheadServers;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule IntraSiteReplicationSchedule
    {
        get
        {
            return this._wrapped.IntraSiteReplicationSchedule;
        }
        set
        {
            this._wrapped.IntraSiteReplicationSchedule = value;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySiteCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] sites);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection sites);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] array, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySiteCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection _wrapped;
    
    public WrappedActiveDirectorySiteCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        return this._wrapped.Add(site);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] sites)
    {
        this._wrapped.AddRange(sites);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection sites)
    {
        this._wrapped.AddRange(sites);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        return this._wrapped.Contains(site);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        return this._wrapped.IndexOf(site);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        this._wrapped.Insert(index, site);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        this._wrapped.Remove(site);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySiteLink {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection Sites {
        get;
    }
    
    int Cost {
        get;
        set;
    }
    
    System.TimeSpan ReplicationInterval {
        get;
        set;
    }
    
    bool ReciprocalReplicationEnabled {
        get;
        set;
    }
    
    bool NotificationEnabled {
        get;
        set;
    }
    
    bool DataCompressionEnabled {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule InterSiteReplicationSchedule {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink Wrapped {
        get;
    }
    
    void Save();
    
    void Delete();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySiteLink
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink _wrapped;
    
    public WrappedActiveDirectorySiteLink(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType
    {
        get
        {
            return this._wrapped.TransportType;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteCollection Sites
    {
        get
        {
            return this._wrapped.Sites;
        }
    }
    
    public virtual int Cost
    {
        get
        {
            return this._wrapped.Cost;
        }
        set
        {
            this._wrapped.Cost = value;
        }
    }
    
    public virtual System.TimeSpan ReplicationInterval
    {
        get
        {
            return this._wrapped.ReplicationInterval;
        }
        set
        {
            this._wrapped.ReplicationInterval = value;
        }
    }
    
    public virtual bool ReciprocalReplicationEnabled
    {
        get
        {
            return this._wrapped.ReciprocalReplicationEnabled;
        }
        set
        {
            this._wrapped.ReciprocalReplicationEnabled = value;
        }
    }
    
    public virtual bool NotificationEnabled
    {
        get
        {
            return this._wrapped.NotificationEnabled;
        }
        set
        {
            this._wrapped.NotificationEnabled = value;
        }
    }
    
    public virtual bool DataCompressionEnabled
    {
        get
        {
            return this._wrapped.DataCompressionEnabled;
        }
        set
        {
            this._wrapped.DataCompressionEnabled = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule InterSiteReplicationSchedule
    {
        get
        {
            return this._wrapped.InterSiteReplicationSchedule;
        }
        set
        {
            this._wrapped.InterSiteReplicationSchedule = value;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySiteLinkBridge {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection SiteLinks {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge Wrapped {
        get;
    }
    
    void Save();
    
    void Delete();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySiteLinkBridge
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge _wrapped;
    
    public WrappedActiveDirectorySiteLinkBridge(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection SiteLinks
    {
        get
        {
            return this._wrapped.SiteLinks;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType
    {
        get
        {
            return this._wrapped.TransportType;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySiteLinkCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] links);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection links);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] array, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySiteLinkCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection _wrapped;
    
    public WrappedActiveDirectorySiteLinkCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        return this._wrapped.Add(link);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] links)
    {
        this._wrapped.AddRange(links);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkCollection links)
    {
        this._wrapped.AddRange(links);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        return this._wrapped.Contains(link);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        return this._wrapped.IndexOf(link);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        this._wrapped.Insert(index, link);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        this._wrapped.Remove(link);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySubnet {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Site {
        get;
        set;
    }
    
    string Location {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet Wrapped {
        get;
    }
    
    void Save();
    
    void Delete();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySubnet
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet _wrapped;
    
    public WrappedActiveDirectorySubnet(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Site
    {
        get
        {
            return this._wrapped.Site;
        }
        set
        {
            this._wrapped.Site = value;
        }
    }
    
    public virtual string Location
    {
        get
        {
            return this._wrapped.Location;
        }
        set
        {
            this._wrapped.Location = value;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectorySubnetCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet[] subnets);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection subnets);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet[] array, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet);
    
    void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectorySubnetCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection _wrapped;
    
    public WrappedActiveDirectorySubnetCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet)
    {
        return this._wrapped.Add(subnet);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet[] subnets)
    {
        this._wrapped.AddRange(subnets);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnetCollection subnets)
    {
        this._wrapped.AddRange(subnets);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet)
    {
        return this._wrapped.Contains(subnet);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet)
    {
        return this._wrapped.IndexOf(subnet);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet)
    {
        this._wrapped.Insert(index, subnet);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.ActiveDirectorySubnet subnet)
    {
        this._wrapped.Remove(subnet);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IAdamInstance {
    
    System.DirectoryServices.ActiveDirectory.ConfigurationSet ConfigurationSet {
        get;
    }
    
    string HostName {
        get;
    }
    
    int LdapPort {
        get;
    }
    
    int SslPort {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamRoleCollection Roles {
        get;
    }
    
    string DefaultPartition {
        get;
        set;
    }
    
    string IPAddress {
        get;
    }
    
    string SiteName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections {
        get;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamInstance Wrapped {
        get;
    }
    
    void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.AdamRole role);
    
    void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.AdamRole role);
    
    void CheckReplicationConsistency();
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation();
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors();
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures();
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath);
    
    void SyncReplicaFromServer(string partition, string sourceServer);
    
    void TriggerSyncReplicaFromNeighbors(string partition);
    
    void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options);
    
    void Save();
    
    void Dispose();
    
    string ToString();
    
    void MoveToAnotherSite(string siteName);
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedAdamInstance
{
    
    private System.DirectoryServices.ActiveDirectory.AdamInstance _wrapped;
    
    public WrappedAdamInstance(System.DirectoryServices.ActiveDirectory.AdamInstance wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ConfigurationSet ConfigurationSet
    {
        get
        {
            return this._wrapped.ConfigurationSet;
        }
    }
    
    public virtual string HostName
    {
        get
        {
            return this._wrapped.HostName;
        }
    }
    
    public virtual int LdapPort
    {
        get
        {
            return this._wrapped.LdapPort;
        }
    }
    
    public virtual int SslPort
    {
        get
        {
            return this._wrapped.SslPort;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamRoleCollection Roles
    {
        get
        {
            return this._wrapped.Roles;
        }
    }
    
    public virtual string DefaultPartition
    {
        get
        {
            return this._wrapped.DefaultPartition;
        }
        set
        {
            this._wrapped.DefaultPartition = value;
        }
    }
    
    public virtual string IPAddress
    {
        get
        {
            return this._wrapped.IPAddress;
        }
    }
    
    public virtual string SiteName
    {
        get
        {
            return this._wrapped.SiteName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback
    {
        get
        {
            return this._wrapped.SyncFromAllServersCallback;
        }
        set
        {
            this._wrapped.SyncFromAllServersCallback = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections
    {
        get
        {
            return this._wrapped.InboundConnections;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections
    {
        get
        {
            return this._wrapped.OutboundConnections;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions
    {
        get
        {
            return this._wrapped.Partitions;
        }
    }
    
    public virtual void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.AdamRole role)
    {
        this._wrapped.TransferRoleOwnership(role);
    }
    
    public virtual void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.AdamRole role)
    {
        this._wrapped.SeizeRoleOwnership(role);
    }
    
    public virtual void CheckReplicationConsistency()
    {
        this._wrapped.CheckReplicationConsistency();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition)
    {
        return this._wrapped.GetReplicationCursors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation()
    {
        return this._wrapped.GetReplicationOperationInformation();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition)
    {
        return this._wrapped.GetReplicationNeighbors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors()
    {
        return this._wrapped.GetAllReplicationNeighbors();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures()
    {
        return this._wrapped.GetReplicationConnectionFailures();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath)
    {
        return this._wrapped.GetReplicationMetadata(objectPath);
    }
    
    public virtual void SyncReplicaFromServer(string partition, string sourceServer)
    {
        this._wrapped.SyncReplicaFromServer(partition, sourceServer);
    }
    
    public virtual void TriggerSyncReplicaFromNeighbors(string partition)
    {
        this._wrapped.TriggerSyncReplicaFromNeighbors(partition);
    }
    
    public virtual void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options)
    {
        this._wrapped.SyncReplicaFromAllServers(partition, options);
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual void MoveToAnotherSite(string siteName)
    {
        this._wrapped.MoveToAnotherSite(siteName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IAdamInstanceCollection {
    
    System.DirectoryServices.ActiveDirectory.AdamInstance Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamInstanceCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.AdamInstance adamInstance);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.AdamInstance adamInstance);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.AdamInstance[] adamInstances, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedAdamInstanceCollection
{
    
    private System.DirectoryServices.ActiveDirectory.AdamInstanceCollection _wrapped;
    
    public WrappedAdamInstanceCollection(System.DirectoryServices.ActiveDirectory.AdamInstanceCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.AdamInstance adamInstance)
    {
        return this._wrapped.Contains(adamInstance);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.AdamInstance adamInstance)
    {
        return this._wrapped.IndexOf(adamInstance);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.AdamInstance[] adamInstances, int index)
    {
        this._wrapped.CopyTo(adamInstances, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IApplicationPartition {
    
    System.DirectoryServices.ActiveDirectory.DirectoryServerCollection DirectoryServers {
        get;
    }
    
    string SecurityReferenceDomain {
        get;
        set;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ApplicationPartition Wrapped {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer();
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(string siteName);
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(bool forceRediscovery);
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(string siteName, bool forceRediscovery);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDirectoryServers();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDirectoryServers(string siteName);
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDiscoverableDirectoryServers();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDiscoverableDirectoryServers(string siteName);
    
    void Delete();
    
    void Save();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedApplicationPartition
{
    
    private System.DirectoryServices.ActiveDirectory.ApplicationPartition _wrapped;
    
    public WrappedApplicationPartition(System.DirectoryServices.ActiveDirectory.ApplicationPartition wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServerCollection DirectoryServers
    {
        get
        {
            return this._wrapped.DirectoryServers;
        }
    }
    
    public virtual string SecurityReferenceDomain
    {
        get
        {
            return this._wrapped.SecurityReferenceDomain;
        }
        set
        {
            this._wrapped.SecurityReferenceDomain = value;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer()
    {
        return this._wrapped.FindDirectoryServer();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(string siteName)
    {
        return this._wrapped.FindDirectoryServer(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(bool forceRediscovery)
    {
        return this._wrapped.FindDirectoryServer(forceRediscovery);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer FindDirectoryServer(string siteName, bool forceRediscovery)
    {
        return this._wrapped.FindDirectoryServer(siteName, forceRediscovery);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDirectoryServers()
    {
        return this._wrapped.FindAllDirectoryServers();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDirectoryServers(string siteName)
    {
        return this._wrapped.FindAllDirectoryServers(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDiscoverableDirectoryServers()
    {
        return this._wrapped.FindAllDiscoverableDirectoryServers();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection FindAllDiscoverableDirectoryServers(string siteName)
    {
        return this._wrapped.FindAllDiscoverableDirectoryServers(siteName);
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IApplicationPartitionCollection {
    
    System.DirectoryServices.ActiveDirectory.ApplicationPartition Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ApplicationPartition applicationPartition);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ApplicationPartition applicationPartition);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ApplicationPartition[] applicationPartitions, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedApplicationPartitionCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection _wrapped;
    
    public WrappedApplicationPartitionCollection(System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ApplicationPartition Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ApplicationPartition applicationPartition)
    {
        return this._wrapped.Contains(applicationPartition);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ApplicationPartition applicationPartition)
    {
        return this._wrapped.IndexOf(applicationPartition);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ApplicationPartition[] applicationPartitions, int index)
    {
        this._wrapped.CopyTo(applicationPartitions, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IAttributeMetadata {
    
    string Name {
        get;
    }
    
    int Version {
        get;
    }
    
    System.DateTime LastOriginatingChangeTime {
        get;
    }
    
    System.Guid LastOriginatingInvocationId {
        get;
    }
    
    long OriginatingChangeUsn {
        get;
    }
    
    long LocalChangeUsn {
        get;
    }
    
    string OriginatingServer {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AttributeMetadata Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedAttributeMetadata
{
    
    private System.DirectoryServices.ActiveDirectory.AttributeMetadata _wrapped;
    
    public WrappedAttributeMetadata(System.DirectoryServices.ActiveDirectory.AttributeMetadata wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual int Version
    {
        get
        {
            return this._wrapped.Version;
        }
    }
    
    public virtual System.DateTime LastOriginatingChangeTime
    {
        get
        {
            return this._wrapped.LastOriginatingChangeTime;
        }
    }
    
    public virtual System.Guid LastOriginatingInvocationId
    {
        get
        {
            return this._wrapped.LastOriginatingInvocationId;
        }
    }
    
    public virtual long OriginatingChangeUsn
    {
        get
        {
            return this._wrapped.OriginatingChangeUsn;
        }
    }
    
    public virtual long LocalChangeUsn
    {
        get
        {
            return this._wrapped.LocalChangeUsn;
        }
    }
    
    public virtual string OriginatingServer
    {
        get
        {
            return this._wrapped.OriginatingServer;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IAttributeMetadataCollection {
    
    System.DirectoryServices.ActiveDirectory.AttributeMetadata Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AttributeMetadataCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.AttributeMetadata metadata);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.AttributeMetadata metadata);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.AttributeMetadata[] metadata, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedAttributeMetadataCollection
{
    
    private System.DirectoryServices.ActiveDirectory.AttributeMetadataCollection _wrapped;
    
    public WrappedAttributeMetadataCollection(System.DirectoryServices.ActiveDirectory.AttributeMetadataCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AttributeMetadata Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.AttributeMetadata metadata)
    {
        return this._wrapped.Contains(metadata);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.AttributeMetadata metadata)
    {
        return this._wrapped.IndexOf(metadata);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.AttributeMetadata[] metadata, int index)
    {
        this._wrapped.CopyTo(metadata, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IConfigurationSet {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection Sites {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamInstanceCollection AdamInstances {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection ApplicationPartitions {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema Schema {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamInstance SchemaRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamInstance NamingRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ConfigurationSet Wrapped {
        get;
    }
    
    void Dispose();
    
    System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance();
    
    System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance(string partitionName);
    
    System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance(string partitionName, string siteName);
    
    System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances();
    
    System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances(string partitionName);
    
    System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances(string partitionName, string siteName);
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    System.DirectoryServices.ActiveDirectory.ReplicationSecurityLevel GetSecurityLevel();
    
    void SetSecurityLevel(System.DirectoryServices.ActiveDirectory.ReplicationSecurityLevel securityLevel);
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedConfigurationSet
{
    
    private System.DirectoryServices.ActiveDirectory.ConfigurationSet _wrapped;
    
    public WrappedConfigurationSet(System.DirectoryServices.ActiveDirectory.ConfigurationSet wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection Sites
    {
        get
        {
            return this._wrapped.Sites;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstanceCollection AdamInstances
    {
        get
        {
            return this._wrapped.AdamInstances;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection ApplicationPartitions
    {
        get
        {
            return this._wrapped.ApplicationPartitions;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema Schema
    {
        get
        {
            return this._wrapped.Schema;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance SchemaRoleOwner
    {
        get
        {
            return this._wrapped.SchemaRoleOwner;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance NamingRoleOwner
    {
        get
        {
            return this._wrapped.NamingRoleOwner;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance()
    {
        return this._wrapped.FindAdamInstance();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance(string partitionName)
    {
        return this._wrapped.FindAdamInstance(partitionName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstance FindAdamInstance(string partitionName, string siteName)
    {
        return this._wrapped.FindAdamInstance(partitionName, siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances()
    {
        return this._wrapped.FindAllAdamInstances();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances(string partitionName)
    {
        return this._wrapped.FindAllAdamInstances(partitionName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamInstanceCollection FindAllAdamInstances(string partitionName, string siteName)
    {
        return this._wrapped.FindAllAdamInstances(partitionName, siteName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationSecurityLevel GetSecurityLevel()
    {
        return this._wrapped.GetSecurityLevel();
    }
    
    public virtual void SetSecurityLevel(System.DirectoryServices.ActiveDirectory.ReplicationSecurityLevel securityLevel)
    {
        this._wrapped.SetSecurityLevel(securityLevel);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryContext {
    
    string Name {
        get;
    }
    
    string UserName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryContextType ContextType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryContext Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryContext
{
    
    private System.DirectoryServices.ActiveDirectory.DirectoryContext _wrapped;
    
    public WrappedDirectoryContext(System.DirectoryServices.ActiveDirectory.DirectoryContext wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string UserName
    {
        get
        {
            return this._wrapped.UserName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryContextType ContextType
    {
        get
        {
            return this._wrapped.ContextType;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDirectoryServerCollection {
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer Item {
        get;
        set;
    }
    
    int Capacity {
        get;
        set;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DirectoryServerCollection Wrapped {
        get;
    }
    
    int Add(System.DirectoryServices.ActiveDirectory.DirectoryServer server);
    
    void AddRange(System.DirectoryServices.ActiveDirectory.DirectoryServer[] servers);
    
    bool Contains(System.DirectoryServices.ActiveDirectory.DirectoryServer server);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.DirectoryServer[] array, int index);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.DirectoryServer server);
    
    void Insert(int index, System.DirectoryServices.ActiveDirectory.DirectoryServer server);
    
    void Remove(System.DirectoryServices.ActiveDirectory.DirectoryServer server);
    
    void Clear();
    
    void RemoveAt(int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDirectoryServerCollection
{
    
    private System.DirectoryServices.ActiveDirectory.DirectoryServerCollection _wrapped;
    
    public WrappedDirectoryServerCollection(System.DirectoryServices.ActiveDirectory.DirectoryServerCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer Item
    {
        get
        {
            return this._wrapped.Item;
        }
        set
        {
            this._wrapped.Item = value;
        }
    }
    
    public virtual int Capacity
    {
        get
        {
            return this._wrapped.Capacity;
        }
        set
        {
            this._wrapped.Capacity = value;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual int Add(System.DirectoryServices.ActiveDirectory.DirectoryServer server)
    {
        return this._wrapped.Add(server);
    }
    
    public virtual void AddRange(System.DirectoryServices.ActiveDirectory.DirectoryServer[] servers)
    {
        this._wrapped.AddRange(servers);
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.DirectoryServer server)
    {
        return this._wrapped.Contains(server);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.DirectoryServer[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.DirectoryServer server)
    {
        return this._wrapped.IndexOf(server);
    }
    
    public virtual void Insert(int index, System.DirectoryServices.ActiveDirectory.DirectoryServer server)
    {
        this._wrapped.Insert(index, server);
    }
    
    public virtual void Remove(System.DirectoryServices.ActiveDirectory.DirectoryServer server)
    {
        this._wrapped.Remove(server);
    }
    
    public virtual void Clear()
    {
        this._wrapped.Clear();
    }
    
    public virtual void RemoveAt(int index)
    {
        this._wrapped.RemoveAt(index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDomain {
    
    System.DirectoryServices.ActiveDirectory.Forest Forest {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection DomainControllers {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainCollection Children {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainMode DomainMode {
        get;
    }
    
    int DomainModeLevel {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Domain Parent {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController PdcRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController RidRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController InfrastructureRoleOwner {
        get;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Domain Wrapped {
        get;
    }
    
    void RaiseDomainFunctionalityLevel(int domainMode);
    
    void RaiseDomainFunctionality(System.DirectoryServices.ActiveDirectory.DomainMode domainMode);
    
    System.DirectoryServices.ActiveDirectory.DomainController FindDomainController();
    
    System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(string siteName);
    
    System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(System.DirectoryServices.ActiveDirectory.LocatorOptions flag);
    
    System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(string siteName, System.DirectoryServices.ActiveDirectory.LocatorOptions flag);
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDomainControllers();
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDomainControllers(string siteName);
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDiscoverableDomainControllers();
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDiscoverableDomainControllers(string siteName);
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection GetAllTrustRelationships();
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation GetTrustRelationship(string targetDomainName);
    
    bool GetSelectiveAuthenticationStatus(string targetDomainName);
    
    void SetSelectiveAuthenticationStatus(string targetDomainName, bool enable);
    
    bool GetSidFilteringStatus(string targetDomainName);
    
    void SetSidFilteringStatus(string targetDomainName, bool enable);
    
    void DeleteLocalSideOfTrustRelationship(string targetDomainName);
    
    void DeleteTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain);
    
    void VerifyOutboundTrustRelationship(string targetDomainName);
    
    void VerifyTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection direction);
    
    void CreateLocalSideOfTrustRelationship(string targetDomainName, System.DirectoryServices.ActiveDirectory.TrustDirection direction, string trustPassword);
    
    void CreateTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection direction);
    
    void UpdateLocalSideOfTrustRelationship(string targetDomainName, string newTrustPassword);
    
    void UpdateLocalSideOfTrustRelationship(string targetDomainName, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection, string newTrustPassword);
    
    void UpdateTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection);
    
    void RepairTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain);
    
    void Dispose();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDomain
{
    
    private System.DirectoryServices.ActiveDirectory.Domain _wrapped;
    
    public WrappedDomain(System.DirectoryServices.ActiveDirectory.Domain wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Forest Forest
    {
        get
        {
            return this._wrapped.Forest;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainControllerCollection DomainControllers
    {
        get
        {
            return this._wrapped.DomainControllers;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainCollection Children
    {
        get
        {
            return this._wrapped.Children;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainMode DomainMode
    {
        get
        {
            return this._wrapped.DomainMode;
        }
    }
    
    public virtual int DomainModeLevel
    {
        get
        {
            return this._wrapped.DomainModeLevel;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Domain Parent
    {
        get
        {
            return this._wrapped.Parent;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController PdcRoleOwner
    {
        get
        {
            return this._wrapped.PdcRoleOwner;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController RidRoleOwner
    {
        get
        {
            return this._wrapped.RidRoleOwner;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController InfrastructureRoleOwner
    {
        get
        {
            return this._wrapped.InfrastructureRoleOwner;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual void RaiseDomainFunctionalityLevel(int domainMode)
    {
        this._wrapped.RaiseDomainFunctionalityLevel(domainMode);
    }
    
    public virtual void RaiseDomainFunctionality(System.DirectoryServices.ActiveDirectory.DomainMode domainMode)
    {
        this._wrapped.RaiseDomainFunctionality(domainMode);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController FindDomainController()
    {
        return this._wrapped.FindDomainController();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(string siteName)
    {
        return this._wrapped.FindDomainController(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(System.DirectoryServices.ActiveDirectory.LocatorOptions flag)
    {
        return this._wrapped.FindDomainController(flag);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController FindDomainController(string siteName, System.DirectoryServices.ActiveDirectory.LocatorOptions flag)
    {
        return this._wrapped.FindDomainController(siteName, flag);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDomainControllers()
    {
        return this._wrapped.FindAllDomainControllers();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDomainControllers(string siteName)
    {
        return this._wrapped.FindAllDomainControllers(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDiscoverableDomainControllers()
    {
        return this._wrapped.FindAllDiscoverableDomainControllers();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainControllerCollection FindAllDiscoverableDomainControllers(string siteName)
    {
        return this._wrapped.FindAllDiscoverableDomainControllers(siteName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection GetAllTrustRelationships()
    {
        return this._wrapped.GetAllTrustRelationships();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation GetTrustRelationship(string targetDomainName)
    {
        return this._wrapped.GetTrustRelationship(targetDomainName);
    }
    
    public virtual bool GetSelectiveAuthenticationStatus(string targetDomainName)
    {
        return this._wrapped.GetSelectiveAuthenticationStatus(targetDomainName);
    }
    
    public virtual void SetSelectiveAuthenticationStatus(string targetDomainName, bool enable)
    {
        this._wrapped.SetSelectiveAuthenticationStatus(targetDomainName, enable);
    }
    
    public virtual bool GetSidFilteringStatus(string targetDomainName)
    {
        return this._wrapped.GetSidFilteringStatus(targetDomainName);
    }
    
    public virtual void SetSidFilteringStatus(string targetDomainName, bool enable)
    {
        this._wrapped.SetSidFilteringStatus(targetDomainName, enable);
    }
    
    public virtual void DeleteLocalSideOfTrustRelationship(string targetDomainName)
    {
        this._wrapped.DeleteLocalSideOfTrustRelationship(targetDomainName);
    }
    
    public virtual void DeleteTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain)
    {
        this._wrapped.DeleteTrustRelationship(targetDomain);
    }
    
    public virtual void VerifyOutboundTrustRelationship(string targetDomainName)
    {
        this._wrapped.VerifyOutboundTrustRelationship(targetDomainName);
    }
    
    public virtual void VerifyTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection direction)
    {
        this._wrapped.VerifyTrustRelationship(targetDomain, direction);
    }
    
    public virtual void CreateLocalSideOfTrustRelationship(string targetDomainName, System.DirectoryServices.ActiveDirectory.TrustDirection direction, string trustPassword)
    {
        this._wrapped.CreateLocalSideOfTrustRelationship(targetDomainName, direction, trustPassword);
    }
    
    public virtual void CreateTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection direction)
    {
        this._wrapped.CreateTrustRelationship(targetDomain, direction);
    }
    
    public virtual void UpdateLocalSideOfTrustRelationship(string targetDomainName, string newTrustPassword)
    {
        this._wrapped.UpdateLocalSideOfTrustRelationship(targetDomainName, newTrustPassword);
    }
    
    public virtual void UpdateLocalSideOfTrustRelationship(string targetDomainName, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection, string newTrustPassword)
    {
        this._wrapped.UpdateLocalSideOfTrustRelationship(targetDomainName, newTrustDirection, newTrustPassword);
    }
    
    public virtual void UpdateTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection)
    {
        this._wrapped.UpdateTrustRelationship(targetDomain, newTrustDirection);
    }
    
    public virtual void RepairTrustRelationship(System.DirectoryServices.ActiveDirectory.Domain targetDomain)
    {
        this._wrapped.RepairTrustRelationship(targetDomain);
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDomainCollection {
    
    System.DirectoryServices.ActiveDirectory.Domain Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.Domain domain);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.Domain domain);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.Domain[] domains, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDomainCollection
{
    
    private System.DirectoryServices.ActiveDirectory.DomainCollection _wrapped;
    
    public WrappedDomainCollection(System.DirectoryServices.ActiveDirectory.DomainCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Domain Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.Domain domain)
    {
        return this._wrapped.Contains(domain);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.Domain domain)
    {
        return this._wrapped.IndexOf(domain);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.Domain[] domains, int index)
    {
        this._wrapped.CopyTo(domains, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISyncUpdateCallback {
    
    System.Reflection.MethodInfo Method {
        get;
    }
    
    object Target {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncUpdateCallback Wrapped {
        get;
    }
    
    bool Invoke(System.DirectoryServices.ActiveDirectory.SyncFromAllServersEvent eventType, string targetServer, string sourceServer, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException exception);
    
    System.IAsyncResult BeginInvoke(System.DirectoryServices.ActiveDirectory.SyncFromAllServersEvent eventType, string targetServer, string sourceServer, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException exception, System.AsyncCallback callback, object @object);
    
    bool EndInvoke(System.IAsyncResult result);
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    
    bool Equals(object obj);
    
    System.Delegate[] GetInvocationList();
    
    int GetHashCode();
    
    object DynamicInvoke(object[] args);
    
    object Clone();
    
    string ToString();
    
    System.Type GetType();
}

public partial class WrappedSyncUpdateCallback
{
    
    private System.DirectoryServices.ActiveDirectory.SyncUpdateCallback _wrapped;
    
    public WrappedSyncUpdateCallback(System.DirectoryServices.ActiveDirectory.SyncUpdateCallback wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.Reflection.MethodInfo Method
    {
        get
        {
            return this._wrapped.Method;
        }
    }
    
    public virtual object Target
    {
        get
        {
            return this._wrapped.Target;
        }
    }
    
    public virtual bool Invoke(System.DirectoryServices.ActiveDirectory.SyncFromAllServersEvent eventType, string targetServer, string sourceServer, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException exception)
    {
        return this._wrapped.Invoke(eventType, targetServer, sourceServer, exception);
    }
    
    public virtual System.IAsyncResult BeginInvoke(System.DirectoryServices.ActiveDirectory.SyncFromAllServersEvent eventType, string targetServer, string sourceServer, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException exception, System.AsyncCallback callback, object @object)
    {
        return this._wrapped.BeginInvoke(eventType, targetServer, sourceServer, exception, callback, @object);
    }
    
    public virtual bool EndInvoke(System.IAsyncResult result)
    {
        return this._wrapped.EndInvoke(result);
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
        this._wrapped.GetObjectData(info, context);
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual System.Delegate[] GetInvocationList()
    {
        return this._wrapped.GetInvocationList();
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual object DynamicInvoke(object[] args)
    {
        return this._wrapped.DynamicInvoke(args);
    }
    
    public virtual object Clone()
    {
        return this._wrapped.Clone();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDomainController {
    
    System.DirectoryServices.ActiveDirectory.Forest Forest {
        get;
    }
    
    System.DateTime CurrentTime {
        get;
    }
    
    long HighestCommittedUsn {
        get;
    }
    
    string OSVersion {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection Roles {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Domain Domain {
        get;
    }
    
    string IPAddress {
        get;
    }
    
    string SiteName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections {
        get;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController Wrapped {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog EnableGlobalCatalog();
    
    bool IsGlobalCatalog();
    
    void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    System.DirectoryServices.DirectorySearcher GetDirectorySearcher();
    
    void CheckReplicationConsistency();
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation();
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors();
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures();
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath);
    
    void SyncReplicaFromServer(string partition, string sourceServer);
    
    void TriggerSyncReplicaFromNeighbors(string partition);
    
    void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options);
    
    void Dispose();
    
    string ToString();
    
    void MoveToAnotherSite(string siteName);
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDomainController
{
    
    private System.DirectoryServices.ActiveDirectory.DomainController _wrapped;
    
    public WrappedDomainController(System.DirectoryServices.ActiveDirectory.DomainController wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Forest Forest
    {
        get
        {
            return this._wrapped.Forest;
        }
    }
    
    public virtual System.DateTime CurrentTime
    {
        get
        {
            return this._wrapped.CurrentTime;
        }
    }
    
    public virtual long HighestCommittedUsn
    {
        get
        {
            return this._wrapped.HighestCommittedUsn;
        }
    }
    
    public virtual string OSVersion
    {
        get
        {
            return this._wrapped.OSVersion;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection Roles
    {
        get
        {
            return this._wrapped.Roles;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Domain Domain
    {
        get
        {
            return this._wrapped.Domain;
        }
    }
    
    public virtual string IPAddress
    {
        get
        {
            return this._wrapped.IPAddress;
        }
    }
    
    public virtual string SiteName
    {
        get
        {
            return this._wrapped.SiteName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback
    {
        get
        {
            return this._wrapped.SyncFromAllServersCallback;
        }
        set
        {
            this._wrapped.SyncFromAllServersCallback = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections
    {
        get
        {
            return this._wrapped.InboundConnections;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections
    {
        get
        {
            return this._wrapped.OutboundConnections;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions
    {
        get
        {
            return this._wrapped.Partitions;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog EnableGlobalCatalog()
    {
        return this._wrapped.EnableGlobalCatalog();
    }
    
    public virtual bool IsGlobalCatalog()
    {
        return this._wrapped.IsGlobalCatalog();
    }
    
    public virtual void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        this._wrapped.TransferRoleOwnership(role);
    }
    
    public virtual void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        this._wrapped.SeizeRoleOwnership(role);
    }
    
    public virtual System.DirectoryServices.DirectorySearcher GetDirectorySearcher()
    {
        return this._wrapped.GetDirectorySearcher();
    }
    
    public virtual void CheckReplicationConsistency()
    {
        this._wrapped.CheckReplicationConsistency();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition)
    {
        return this._wrapped.GetReplicationCursors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation()
    {
        return this._wrapped.GetReplicationOperationInformation();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition)
    {
        return this._wrapped.GetReplicationNeighbors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors()
    {
        return this._wrapped.GetAllReplicationNeighbors();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures()
    {
        return this._wrapped.GetReplicationConnectionFailures();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath)
    {
        return this._wrapped.GetReplicationMetadata(objectPath);
    }
    
    public virtual void SyncReplicaFromServer(string partition, string sourceServer)
    {
        this._wrapped.SyncReplicaFromServer(partition, sourceServer);
    }
    
    public virtual void TriggerSyncReplicaFromNeighbors(string partition)
    {
        this._wrapped.TriggerSyncReplicaFromNeighbors(partition);
    }
    
    public virtual void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options)
    {
        this._wrapped.SyncReplicaFromAllServers(partition, options);
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual void MoveToAnotherSite(string siteName)
    {
        this._wrapped.MoveToAnotherSite(siteName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IDomainControllerCollection {
    
    System.DirectoryServices.ActiveDirectory.DomainController Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainControllerCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.DomainController domainController);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.DomainController domainController);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.DomainController[] domainControllers, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedDomainControllerCollection
{
    
    private System.DirectoryServices.ActiveDirectory.DomainControllerCollection _wrapped;
    
    public WrappedDomainControllerCollection(System.DirectoryServices.ActiveDirectory.DomainControllerCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.DomainController domainController)
    {
        return this._wrapped.Contains(domainController);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.DomainController domainController)
    {
        return this._wrapped.IndexOf(domainController);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.DomainController[] domainControllers, int index)
    {
        this._wrapped.CopyTo(domainControllers, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISyncFromAllServersErrorInformation {
    
    System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorCategory ErrorCategory {
        get;
    }
    
    int ErrorCode {
        get;
    }
    
    string ErrorMessage {
        get;
    }
    
    string TargetServer {
        get;
    }
    
    string SourceServer {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorInformation Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSyncFromAllServersErrorInformation
{
    
    private System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorInformation _wrapped;
    
    public WrappedSyncFromAllServersErrorInformation(System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorInformation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorCategory ErrorCategory
    {
        get
        {
            return this._wrapped.ErrorCategory;
        }
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string ErrorMessage
    {
        get
        {
            return this._wrapped.ErrorMessage;
        }
    }
    
    public virtual string TargetServer
    {
        get
        {
            return this._wrapped.TargetServer;
        }
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryObjectNotFoundException {
    
    System.Type Type {
        get;
    }
    
    string Name {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    System.Exception GetBaseException();
    
    string ToString();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryObjectNotFoundException
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException _wrapped;
    
    public WrappedActiveDirectoryObjectNotFoundException(System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectNotFoundException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.Type Type
    {
        get
        {
            return this._wrapped.Type;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryOperationException {
    
    int ErrorCode {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    System.Exception GetBaseException();
    
    string ToString();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryOperationException
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException _wrapped;
    
    public WrappedActiveDirectoryOperationException(System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryServerDownException {
    
    int ErrorCode {
        get;
    }
    
    string Name {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    System.Exception GetBaseException();
    
    string ToString();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryServerDownException
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException _wrapped;
    
    public WrappedActiveDirectoryServerDownException(System.DirectoryServices.ActiveDirectory.ActiveDirectoryServerDownException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryObjectExistsException {
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException Wrapped {
        get;
    }
    
    System.Exception GetBaseException();
    
    string ToString();
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryObjectExistsException
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException _wrapped;
    
    public WrappedActiveDirectoryObjectExistsException(System.DirectoryServices.ActiveDirectory.ActiveDirectoryObjectExistsException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
    {
        this._wrapped.GetObjectData(info, context);
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ISyncFromAllServersOperationException {
    
    System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorInformation[] ErrorInformation {
        get;
    }
    
    int ErrorCode {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    System.Exception GetBaseException();
    
    string ToString();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedSyncFromAllServersOperationException
{
    
    private System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException _wrapped;
    
    public WrappedSyncFromAllServersOperationException(System.DirectoryServices.ActiveDirectory.SyncFromAllServersOperationException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SyncFromAllServersErrorInformation[] ErrorInformation
    {
        get
        {
            return this._wrapped.ErrorInformation;
        }
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustCollisionException {
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollisionCollection Collisions {
        get;
    }
    
    int ErrorCode {
        get;
    }
    
    string Message {
        get;
    }
    
    System.Collections.IDictionary Data {
        get;
    }
    
    System.Exception InnerException {
        get;
    }
    
    System.Reflection.MethodBase TargetSite {
        get;
    }
    
    string StackTrace {
        get;
    }
    
    string HelpLink {
        get;
        set;
    }
    
    string Source {
        get;
        set;
    }
    
    int HResult {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException Wrapped {
        get;
    }
    
    void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext);
    
    System.Exception GetBaseException();
    
    string ToString();
    
    System.Type GetType();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustCollisionException
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException _wrapped;
    
    public WrappedForestTrustCollisionException(System.DirectoryServices.ActiveDirectory.ForestTrustCollisionException wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollisionCollection Collisions
    {
        get
        {
            return this._wrapped.Collisions;
        }
    }
    
    public virtual int ErrorCode
    {
        get
        {
            return this._wrapped.ErrorCode;
        }
    }
    
    public virtual string Message
    {
        get
        {
            return this._wrapped.Message;
        }
    }
    
    public virtual System.Collections.IDictionary Data
    {
        get
        {
            return this._wrapped.Data;
        }
    }
    
    public virtual System.Exception InnerException
    {
        get
        {
            return this._wrapped.InnerException;
        }
    }
    
    public virtual System.Reflection.MethodBase TargetSite
    {
        get
        {
            return this._wrapped.TargetSite;
        }
    }
    
    public virtual string StackTrace
    {
        get
        {
            return this._wrapped.StackTrace;
        }
    }
    
    public virtual string HelpLink
    {
        get
        {
            return this._wrapped.HelpLink;
        }
        set
        {
            this._wrapped.HelpLink = value;
        }
    }
    
    public virtual string Source
    {
        get
        {
            return this._wrapped.Source;
        }
        set
        {
            this._wrapped.Source = value;
        }
    }
    
    public virtual int HResult
    {
        get
        {
            return this._wrapped.HResult;
        }
        set
        {
            this._wrapped.HResult = value;
        }
    }
    
    public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
    {
        this._wrapped.GetObjectData(serializationInfo, streamingContext);
    }
    
    public virtual System.Exception GetBaseException()
    {
        return this._wrapped.GetBaseException();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForest {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection Sites {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainCollection Domains {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection GlobalCatalogs {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection ApplicationPartitions {
        get;
    }
    
    int ForestModeLevel {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestMode ForestMode {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Domain RootDomain {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema Schema {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController SchemaRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainController NamingRoleOwner {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Forest Wrapped {
        get;
    }
    
    void Dispose();
    
    void RaiseForestFunctionalityLevel(int forestMode);
    
    void RaiseForestFunctionality(System.DirectoryServices.ActiveDirectory.ForestMode forestMode);
    
    string ToString();
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog();
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(string siteName);
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(System.DirectoryServices.ActiveDirectory.LocatorOptions flag);
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(string siteName, System.DirectoryServices.ActiveDirectory.LocatorOptions flag);
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllGlobalCatalogs();
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllGlobalCatalogs(string siteName);
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllDiscoverableGlobalCatalogs();
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllDiscoverableGlobalCatalogs(string siteName);
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection GetAllTrustRelationships();
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipInformation GetTrustRelationship(string targetForestName);
    
    bool GetSelectiveAuthenticationStatus(string targetForestName);
    
    void SetSelectiveAuthenticationStatus(string targetForestName, bool enable);
    
    bool GetSidFilteringStatus(string targetForestName);
    
    void SetSidFilteringStatus(string targetForestName, bool enable);
    
    void DeleteLocalSideOfTrustRelationship(string targetForestName);
    
    void DeleteTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest);
    
    void VerifyOutboundTrustRelationship(string targetForestName);
    
    void VerifyTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection direction);
    
    void CreateLocalSideOfTrustRelationship(string targetForestName, System.DirectoryServices.ActiveDirectory.TrustDirection direction, string trustPassword);
    
    void CreateTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection direction);
    
    void UpdateLocalSideOfTrustRelationship(string targetForestName, string newTrustPassword);
    
    void UpdateLocalSideOfTrustRelationship(string targetForestName, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection, string newTrustPassword);
    
    void UpdateTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection);
    
    void RepairTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest);
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForest
{
    
    private System.DirectoryServices.ActiveDirectory.Forest _wrapped;
    
    public WrappedForest(System.DirectoryServices.ActiveDirectory.Forest wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection Sites
    {
        get
        {
            return this._wrapped.Sites;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainCollection Domains
    {
        get
        {
            return this._wrapped.Domains;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection GlobalCatalogs
    {
        get
        {
            return this._wrapped.GlobalCatalogs;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ApplicationPartitionCollection ApplicationPartitions
    {
        get
        {
            return this._wrapped.ApplicationPartitions;
        }
    }
    
    public virtual int ForestModeLevel
    {
        get
        {
            return this._wrapped.ForestModeLevel;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestMode ForestMode
    {
        get
        {
            return this._wrapped.ForestMode;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Domain RootDomain
    {
        get
        {
            return this._wrapped.RootDomain;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchema Schema
    {
        get
        {
            return this._wrapped.Schema;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController SchemaRoleOwner
    {
        get
        {
            return this._wrapped.SchemaRoleOwner;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController NamingRoleOwner
    {
        get
        {
            return this._wrapped.NamingRoleOwner;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual void RaiseForestFunctionalityLevel(int forestMode)
    {
        this._wrapped.RaiseForestFunctionalityLevel(forestMode);
    }
    
    public virtual void RaiseForestFunctionality(System.DirectoryServices.ActiveDirectory.ForestMode forestMode)
    {
        this._wrapped.RaiseForestFunctionality(forestMode);
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog()
    {
        return this._wrapped.FindGlobalCatalog();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(string siteName)
    {
        return this._wrapped.FindGlobalCatalog(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(System.DirectoryServices.ActiveDirectory.LocatorOptions flag)
    {
        return this._wrapped.FindGlobalCatalog(flag);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog FindGlobalCatalog(string siteName, System.DirectoryServices.ActiveDirectory.LocatorOptions flag)
    {
        return this._wrapped.FindGlobalCatalog(siteName, flag);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllGlobalCatalogs()
    {
        return this._wrapped.FindAllGlobalCatalogs();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllGlobalCatalogs(string siteName)
    {
        return this._wrapped.FindAllGlobalCatalogs(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllDiscoverableGlobalCatalogs()
    {
        return this._wrapped.FindAllDiscoverableGlobalCatalogs();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection FindAllDiscoverableGlobalCatalogs(string siteName)
    {
        return this._wrapped.FindAllDiscoverableGlobalCatalogs(siteName);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection GetAllTrustRelationships()
    {
        return this._wrapped.GetAllTrustRelationships();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipInformation GetTrustRelationship(string targetForestName)
    {
        return this._wrapped.GetTrustRelationship(targetForestName);
    }
    
    public virtual bool GetSelectiveAuthenticationStatus(string targetForestName)
    {
        return this._wrapped.GetSelectiveAuthenticationStatus(targetForestName);
    }
    
    public virtual void SetSelectiveAuthenticationStatus(string targetForestName, bool enable)
    {
        this._wrapped.SetSelectiveAuthenticationStatus(targetForestName, enable);
    }
    
    public virtual bool GetSidFilteringStatus(string targetForestName)
    {
        return this._wrapped.GetSidFilteringStatus(targetForestName);
    }
    
    public virtual void SetSidFilteringStatus(string targetForestName, bool enable)
    {
        this._wrapped.SetSidFilteringStatus(targetForestName, enable);
    }
    
    public virtual void DeleteLocalSideOfTrustRelationship(string targetForestName)
    {
        this._wrapped.DeleteLocalSideOfTrustRelationship(targetForestName);
    }
    
    public virtual void DeleteTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest)
    {
        this._wrapped.DeleteTrustRelationship(targetForest);
    }
    
    public virtual void VerifyOutboundTrustRelationship(string targetForestName)
    {
        this._wrapped.VerifyOutboundTrustRelationship(targetForestName);
    }
    
    public virtual void VerifyTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection direction)
    {
        this._wrapped.VerifyTrustRelationship(targetForest, direction);
    }
    
    public virtual void CreateLocalSideOfTrustRelationship(string targetForestName, System.DirectoryServices.ActiveDirectory.TrustDirection direction, string trustPassword)
    {
        this._wrapped.CreateLocalSideOfTrustRelationship(targetForestName, direction, trustPassword);
    }
    
    public virtual void CreateTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection direction)
    {
        this._wrapped.CreateTrustRelationship(targetForest, direction);
    }
    
    public virtual void UpdateLocalSideOfTrustRelationship(string targetForestName, string newTrustPassword)
    {
        this._wrapped.UpdateLocalSideOfTrustRelationship(targetForestName, newTrustPassword);
    }
    
    public virtual void UpdateLocalSideOfTrustRelationship(string targetForestName, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection, string newTrustPassword)
    {
        this._wrapped.UpdateLocalSideOfTrustRelationship(targetForestName, newTrustDirection, newTrustPassword);
    }
    
    public virtual void UpdateTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest, System.DirectoryServices.ActiveDirectory.TrustDirection newTrustDirection)
    {
        this._wrapped.UpdateTrustRelationship(targetForest, newTrustDirection);
    }
    
    public virtual void RepairTrustRelationship(System.DirectoryServices.ActiveDirectory.Forest targetForest)
    {
        this._wrapped.RepairTrustRelationship(targetForest);
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustRelationshipCollision {
    
    System.DirectoryServices.ActiveDirectory.ForestTrustCollisionType CollisionType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TopLevelNameCollisionOptions TopLevelNameCollisionOption {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.DomainCollisionOptions DomainCollisionOption {
        get;
    }
    
    string CollisionRecord {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustRelationshipCollision
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision _wrapped;
    
    public WrappedForestTrustRelationshipCollision(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustCollisionType CollisionType
    {
        get
        {
            return this._wrapped.CollisionType;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TopLevelNameCollisionOptions TopLevelNameCollisionOption
    {
        get
        {
            return this._wrapped.TopLevelNameCollisionOption;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainCollisionOptions DomainCollisionOption
    {
        get
        {
            return this._wrapped.DomainCollisionOption;
        }
    }
    
    public virtual string CollisionRecord
    {
        get
        {
            return this._wrapped.CollisionRecord;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustRelationshipCollisionCollection {
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollisionCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision collision);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision collision);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision[] array, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustRelationshipCollisionCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollisionCollection _wrapped;
    
    public WrappedForestTrustRelationshipCollisionCollection(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollisionCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision collision)
    {
        return this._wrapped.Contains(collision);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision collision)
    {
        return this._wrapped.IndexOf(collision);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipCollision[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustDomainInfoCollection {
    
    System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustDomainInfoCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation information);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation information);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation[] array, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustDomainInfoCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustDomainInfoCollection _wrapped;
    
    public WrappedForestTrustDomainInfoCollection(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInfoCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation information)
    {
        return this._wrapped.Contains(information);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation information)
    {
        return this._wrapped.IndexOf(information);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustDomainInformation {
    
    string DnsName {
        get;
    }
    
    string NetBiosName {
        get;
    }
    
    string DomainSid {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustDomainStatus Status {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustDomainInformation
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation _wrapped;
    
    public WrappedForestTrustDomainInformation(System.DirectoryServices.ActiveDirectory.ForestTrustDomainInformation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string DnsName
    {
        get
        {
            return this._wrapped.DnsName;
        }
    }
    
    public virtual string NetBiosName
    {
        get
        {
            return this._wrapped.NetBiosName;
        }
    }
    
    public virtual string DomainSid
    {
        get
        {
            return this._wrapped.DomainSid;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustDomainStatus Status
    {
        get
        {
            return this._wrapped.Status;
        }
        set
        {
            this._wrapped.Status = value;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IForestTrustRelationshipInformation {
    
    System.DirectoryServices.ActiveDirectory.TopLevelNameCollection TopLevelNames {
        get;
    }
    
    System.Collections.Specialized.StringCollection ExcludedTopLevelNames {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustDomainInfoCollection TrustedDomainInformation {
        get;
    }
    
    string SourceName {
        get;
    }
    
    string TargetName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustType TrustType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustDirection TrustDirection {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipInformation Wrapped {
        get;
    }
    
    void Save();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedForestTrustRelationshipInformation
{
    
    private System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipInformation _wrapped;
    
    public WrappedForestTrustRelationshipInformation(System.DirectoryServices.ActiveDirectory.ForestTrustRelationshipInformation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TopLevelNameCollection TopLevelNames
    {
        get
        {
            return this._wrapped.TopLevelNames;
        }
    }
    
    public virtual System.Collections.Specialized.StringCollection ExcludedTopLevelNames
    {
        get
        {
            return this._wrapped.ExcludedTopLevelNames;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ForestTrustDomainInfoCollection TrustedDomainInformation
    {
        get
        {
            return this._wrapped.TrustedDomainInformation;
        }
    }
    
    public virtual string SourceName
    {
        get
        {
            return this._wrapped.SourceName;
        }
    }
    
    public virtual string TargetName
    {
        get
        {
            return this._wrapped.TargetName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustType TrustType
    {
        get
        {
            return this._wrapped.TrustType;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustDirection TrustDirection
    {
        get
        {
            return this._wrapped.TrustDirection;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IGlobalCatalog {
    
    System.DirectoryServices.ActiveDirectory.Forest Forest {
        get;
    }
    
    System.DateTime CurrentTime {
        get;
    }
    
    long HighestCommittedUsn {
        get;
    }
    
    string OSVersion {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection Roles {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.Domain Domain {
        get;
    }
    
    string IPAddress {
        get;
    }
    
    string SiteName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections {
        get;
    }
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog Wrapped {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog EnableGlobalCatalog();
    
    System.DirectoryServices.ActiveDirectory.DomainController DisableGlobalCatalog();
    
    bool IsGlobalCatalog();
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties();
    
    System.DirectoryServices.DirectorySearcher GetDirectorySearcher();
    
    void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    void CheckReplicationConsistency();
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation();
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition);
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors();
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures();
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath);
    
    void SyncReplicaFromServer(string partition, string sourceServer);
    
    void TriggerSyncReplicaFromNeighbors(string partition);
    
    void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options);
    
    void Dispose();
    
    string ToString();
    
    void MoveToAnotherSite(string siteName);
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedGlobalCatalog
{
    
    private System.DirectoryServices.ActiveDirectory.GlobalCatalog _wrapped;
    
    public WrappedGlobalCatalog(System.DirectoryServices.ActiveDirectory.GlobalCatalog wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Forest Forest
    {
        get
        {
            return this._wrapped.Forest;
        }
    }
    
    public virtual System.DateTime CurrentTime
    {
        get
        {
            return this._wrapped.CurrentTime;
        }
    }
    
    public virtual long HighestCommittedUsn
    {
        get
        {
            return this._wrapped.HighestCommittedUsn;
        }
    }
    
    public virtual string OSVersion
    {
        get
        {
            return this._wrapped.OSVersion;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection Roles
    {
        get
        {
            return this._wrapped.Roles;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.Domain Domain
    {
        get
        {
            return this._wrapped.Domain;
        }
    }
    
    public virtual string IPAddress
    {
        get
        {
            return this._wrapped.IPAddress;
        }
    }
    
    public virtual string SiteName
    {
        get
        {
            return this._wrapped.SiteName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.SyncUpdateCallback SyncFromAllServersCallback
    {
        get
        {
            return this._wrapped.SyncFromAllServersCallback;
        }
        set
        {
            this._wrapped.SyncFromAllServersCallback = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection InboundConnections
    {
        get
        {
            return this._wrapped.InboundConnections;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection OutboundConnections
    {
        get
        {
            return this._wrapped.OutboundConnections;
        }
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Partitions
    {
        get
        {
            return this._wrapped.Partitions;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog EnableGlobalCatalog()
    {
        return this._wrapped.EnableGlobalCatalog();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DomainController DisableGlobalCatalog()
    {
        return this._wrapped.DisableGlobalCatalog();
    }
    
    public virtual bool IsGlobalCatalog()
    {
        return this._wrapped.IsGlobalCatalog();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection FindAllProperties()
    {
        return this._wrapped.FindAllProperties();
    }
    
    public virtual System.DirectoryServices.DirectorySearcher GetDirectorySearcher()
    {
        return this._wrapped.GetDirectorySearcher();
    }
    
    public virtual void TransferRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        this._wrapped.TransferRoleOwnership(role);
    }
    
    public virtual void SeizeRoleOwnership(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        this._wrapped.SeizeRoleOwnership(role);
    }
    
    public virtual void CheckReplicationConsistency()
    {
        this._wrapped.CheckReplicationConsistency();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection GetReplicationCursors(string partition)
    {
        return this._wrapped.GetReplicationCursors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation GetReplicationOperationInformation()
    {
        return this._wrapped.GetReplicationOperationInformation();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetReplicationNeighbors(string partition)
    {
        return this._wrapped.GetReplicationNeighbors(partition);
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection GetAllReplicationNeighbors()
    {
        return this._wrapped.GetAllReplicationNeighbors();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection GetReplicationConnectionFailures()
    {
        return this._wrapped.GetReplicationConnectionFailures();
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryReplicationMetadata GetReplicationMetadata(string objectPath)
    {
        return this._wrapped.GetReplicationMetadata(objectPath);
    }
    
    public virtual void SyncReplicaFromServer(string partition, string sourceServer)
    {
        this._wrapped.SyncReplicaFromServer(partition, sourceServer);
    }
    
    public virtual void TriggerSyncReplicaFromNeighbors(string partition)
    {
        this._wrapped.TriggerSyncReplicaFromNeighbors(partition);
    }
    
    public virtual void SyncReplicaFromAllServers(string partition, System.DirectoryServices.ActiveDirectory.SyncFromAllServersOptions options)
    {
        this._wrapped.SyncReplicaFromAllServers(partition, options);
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual void MoveToAnotherSite(string siteName)
    {
        this._wrapped.MoveToAnotherSite(siteName);
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IGlobalCatalogCollection {
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalog Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.GlobalCatalog globalCatalog);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.GlobalCatalog globalCatalog);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.GlobalCatalog[] globalCatalogs, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedGlobalCatalogCollection
{
    
    private System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection _wrapped;
    
    public WrappedGlobalCatalogCollection(System.DirectoryServices.ActiveDirectory.GlobalCatalogCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.GlobalCatalog Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.GlobalCatalog globalCatalog)
    {
        return this._wrapped.Contains(globalCatalog);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.GlobalCatalog globalCatalog)
    {
        return this._wrapped.IndexOf(globalCatalog);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.GlobalCatalog[] globalCatalogs, int index)
    {
        this._wrapped.CopyTo(globalCatalogs, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlyActiveDirectorySchemaClassCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] classes, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlyActiveDirectorySchemaClassCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection _wrapped;
    
    public WrappedReadOnlyActiveDirectorySchemaClassCollection(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaClassCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        return this._wrapped.Contains(schemaClass);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass schemaClass)
    {
        return this._wrapped.IndexOf(schemaClass);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaClass[] classes, int index)
    {
        this._wrapped.CopyTo(classes, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlyActiveDirectorySchemaPropertyCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlyActiveDirectorySchemaPropertyCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection _wrapped;
    
    public WrappedReadOnlyActiveDirectorySchemaPropertyCollection(System.DirectoryServices.ActiveDirectory.ReadOnlyActiveDirectorySchemaPropertyCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        return this._wrapped.Contains(schemaProperty);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty schemaProperty)
    {
        return this._wrapped.IndexOf(schemaProperty);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySchemaProperty[] properties, int index)
    {
        this._wrapped.CopyTo(properties, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlyDirectoryServerCollection {
    
    System.DirectoryServices.ActiveDirectory.DirectoryServer Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.DirectoryServer directoryServer);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.DirectoryServer directoryServer);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.DirectoryServer[] directoryServers, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlyDirectoryServerCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection _wrapped;
    
    public WrappedReadOnlyDirectoryServerCollection(System.DirectoryServices.ActiveDirectory.ReadOnlyDirectoryServerCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.DirectoryServer Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.DirectoryServer directoryServer)
    {
        return this._wrapped.Contains(directoryServer);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.DirectoryServer directoryServer)
    {
        return this._wrapped.IndexOf(directoryServer);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.DirectoryServer[] directoryServers, int index)
    {
        this._wrapped.CopyTo(directoryServers, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlySiteCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] sites, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlySiteCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection _wrapped;
    
    public WrappedReadOnlySiteCollection(System.DirectoryServices.ActiveDirectory.ReadOnlySiteCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySite Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        return this._wrapped.Contains(site);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site)
    {
        return this._wrapped.IndexOf(site);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySite[] sites, int index)
    {
        this._wrapped.CopyTo(sites, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlySiteLinkBridgeCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkBridgeCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge bridge);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge bridge);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge[] bridges, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlySiteLinkBridgeCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkBridgeCollection _wrapped;
    
    public WrappedReadOnlySiteLinkBridgeCollection(System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkBridgeCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge bridge)
    {
        return this._wrapped.Contains(bridge);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge bridge)
    {
        return this._wrapped.IndexOf(bridge);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLinkBridge[] bridges, int index)
    {
        this._wrapped.CopyTo(bridges, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlySiteLinkCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] links, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlySiteLinkCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection _wrapped;
    
    public WrappedReadOnlySiteLinkCollection(System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        return this._wrapped.Contains(link);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink link)
    {
        return this._wrapped.IndexOf(link);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectorySiteLink[] links, int index)
    {
        this._wrapped.CopyTo(links, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReadOnlyStringCollection {
    
    string Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection Wrapped {
        get;
    }
    
    bool Contains(string value);
    
    int IndexOf(string value);
    
    void CopyTo(string[] values, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReadOnlyStringCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection _wrapped;
    
    public WrappedReadOnlyStringCollection(System.DirectoryServices.ActiveDirectory.ReadOnlyStringCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(string value)
    {
        return this._wrapped.Contains(value);
    }
    
    public virtual int IndexOf(string value)
    {
        return this._wrapped.IndexOf(value);
    }
    
    public virtual void CopyTo(string[] values, int index)
    {
        this._wrapped.CopyTo(values, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationConnection {
    
    string Name {
        get;
    }
    
    string SourceServer {
        get;
    }
    
    string DestinationServer {
        get;
    }
    
    bool Enabled {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType {
        get;
    }
    
    bool GeneratedByKcc {
        get;
        set;
    }
    
    bool ReciprocalReplicationEnabled {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.NotificationStatus ChangeNotificationStatus {
        get;
        set;
    }
    
    bool DataCompressionEnabled {
        get;
        set;
    }
    
    bool ReplicationScheduleOwnedByUser {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationSpan ReplicationSpan {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule ReplicationSchedule {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnection Wrapped {
        get;
    }
    
    void Dispose();
    
    void Delete();
    
    void Save();
    
    string ToString();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationConnection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationConnection _wrapped;
    
    public WrappedReplicationConnection(System.DirectoryServices.ActiveDirectory.ReplicationConnection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual string DestinationServer
    {
        get
        {
            return this._wrapped.DestinationServer;
        }
    }
    
    public virtual bool Enabled
    {
        get
        {
            return this._wrapped.Enabled;
        }
        set
        {
            this._wrapped.Enabled = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType
    {
        get
        {
            return this._wrapped.TransportType;
        }
    }
    
    public virtual bool GeneratedByKcc
    {
        get
        {
            return this._wrapped.GeneratedByKcc;
        }
        set
        {
            this._wrapped.GeneratedByKcc = value;
        }
    }
    
    public virtual bool ReciprocalReplicationEnabled
    {
        get
        {
            return this._wrapped.ReciprocalReplicationEnabled;
        }
        set
        {
            this._wrapped.ReciprocalReplicationEnabled = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.NotificationStatus ChangeNotificationStatus
    {
        get
        {
            return this._wrapped.ChangeNotificationStatus;
        }
        set
        {
            this._wrapped.ChangeNotificationStatus = value;
        }
    }
    
    public virtual bool DataCompressionEnabled
    {
        get
        {
            return this._wrapped.DataCompressionEnabled;
        }
        set
        {
            this._wrapped.DataCompressionEnabled = value;
        }
    }
    
    public virtual bool ReplicationScheduleOwnedByUser
    {
        get
        {
            return this._wrapped.ReplicationScheduleOwnedByUser;
        }
        set
        {
            this._wrapped.ReplicationScheduleOwnedByUser = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationSpan ReplicationSpan
    {
        get
        {
            return this._wrapped.ReplicationSpan;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectorySchedule ReplicationSchedule
    {
        get
        {
            return this._wrapped.ReplicationSchedule;
        }
        set
        {
            this._wrapped.ReplicationSchedule = value;
        }
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual void Delete()
    {
        this._wrapped.Delete();
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationConnectionCollection {
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnection Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationConnection connection);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationConnection connection);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationConnection[] connections, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationConnectionCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection _wrapped;
    
    public WrappedReplicationConnectionCollection(System.DirectoryServices.ActiveDirectory.ReplicationConnectionCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationConnection Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationConnection connection)
    {
        return this._wrapped.Contains(connection);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationConnection connection)
    {
        return this._wrapped.IndexOf(connection);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationConnection[] connections, int index)
    {
        this._wrapped.CopyTo(connections, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationCursor {
    
    string PartitionName {
        get;
    }
    
    System.Guid SourceInvocationId {
        get;
    }
    
    long UpToDatenessUsn {
        get;
    }
    
    string SourceServer {
        get;
    }
    
    System.DateTime LastSuccessfulSyncTime {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursor Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationCursor
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationCursor _wrapped;
    
    public WrappedReplicationCursor(System.DirectoryServices.ActiveDirectory.ReplicationCursor wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string PartitionName
    {
        get
        {
            return this._wrapped.PartitionName;
        }
    }
    
    public virtual System.Guid SourceInvocationId
    {
        get
        {
            return this._wrapped.SourceInvocationId;
        }
    }
    
    public virtual long UpToDatenessUsn
    {
        get
        {
            return this._wrapped.UpToDatenessUsn;
        }
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual System.DateTime LastSuccessfulSyncTime
    {
        get
        {
            return this._wrapped.LastSuccessfulSyncTime;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationCursorCollection {
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursor Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationCursor cursor);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationCursor cursor);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationCursor[] values, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationCursorCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection _wrapped;
    
    public WrappedReplicationCursorCollection(System.DirectoryServices.ActiveDirectory.ReplicationCursorCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationCursor Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationCursor cursor)
    {
        return this._wrapped.Contains(cursor);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationCursor cursor)
    {
        return this._wrapped.IndexOf(cursor);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationCursor[] values, int index)
    {
        this._wrapped.CopyTo(values, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationFailure {
    
    string SourceServer {
        get;
    }
    
    System.DateTime FirstFailureTime {
        get;
    }
    
    int ConsecutiveFailureCount {
        get;
    }
    
    int LastErrorCode {
        get;
    }
    
    string LastErrorMessage {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailure Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationFailure
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationFailure _wrapped;
    
    public WrappedReplicationFailure(System.DirectoryServices.ActiveDirectory.ReplicationFailure wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual System.DateTime FirstFailureTime
    {
        get
        {
            return this._wrapped.FirstFailureTime;
        }
    }
    
    public virtual int ConsecutiveFailureCount
    {
        get
        {
            return this._wrapped.ConsecutiveFailureCount;
        }
    }
    
    public virtual int LastErrorCode
    {
        get
        {
            return this._wrapped.LastErrorCode;
        }
    }
    
    public virtual string LastErrorMessage
    {
        get
        {
            return this._wrapped.LastErrorMessage;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationFailureCollection {
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailure Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationFailure failure);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationFailure failure);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationFailure[] failures, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationFailureCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection _wrapped;
    
    public WrappedReplicationFailureCollection(System.DirectoryServices.ActiveDirectory.ReplicationFailureCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationFailure Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationFailure failure)
    {
        return this._wrapped.Contains(failure);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationFailure failure)
    {
        return this._wrapped.IndexOf(failure);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationFailure[] failures, int index)
    {
        this._wrapped.CopyTo(failures, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationNeighbor {
    
    string PartitionName {
        get;
    }
    
    string SourceServer {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighbor.ReplicationNeighborOptions ReplicationNeighborOption {
        get;
    }
    
    System.Guid SourceInvocationId {
        get;
    }
    
    long UsnLastObjectChangeSynced {
        get;
    }
    
    long UsnAttributeFilter {
        get;
    }
    
    System.DateTime LastSuccessfulSync {
        get;
    }
    
    System.DateTime LastAttemptedSync {
        get;
    }
    
    int LastSyncResult {
        get;
    }
    
    string LastSyncMessage {
        get;
    }
    
    int ConsecutiveFailureCount {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighbor Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationNeighbor
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationNeighbor _wrapped;
    
    public WrappedReplicationNeighbor(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string PartitionName
    {
        get
        {
            return this._wrapped.PartitionName;
        }
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType
    {
        get
        {
            return this._wrapped.TransportType;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighbor.ReplicationNeighborOptions ReplicationNeighborOption
    {
        get
        {
            return this._wrapped.ReplicationNeighborOption;
        }
    }
    
    public virtual System.Guid SourceInvocationId
    {
        get
        {
            return this._wrapped.SourceInvocationId;
        }
    }
    
    public virtual long UsnLastObjectChangeSynced
    {
        get
        {
            return this._wrapped.UsnLastObjectChangeSynced;
        }
    }
    
    public virtual long UsnAttributeFilter
    {
        get
        {
            return this._wrapped.UsnAttributeFilter;
        }
    }
    
    public virtual System.DateTime LastSuccessfulSync
    {
        get
        {
            return this._wrapped.LastSuccessfulSync;
        }
    }
    
    public virtual System.DateTime LastAttemptedSync
    {
        get
        {
            return this._wrapped.LastAttemptedSync;
        }
    }
    
    public virtual int LastSyncResult
    {
        get
        {
            return this._wrapped.LastSyncResult;
        }
    }
    
    public virtual string LastSyncMessage
    {
        get
        {
            return this._wrapped.LastSyncMessage;
        }
    }
    
    public virtual int ConsecutiveFailureCount
    {
        get
        {
            return this._wrapped.ConsecutiveFailureCount;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationNeighborCollection {
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighbor Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor neighbor);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor neighbor);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor[] neighbors, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationNeighborCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection _wrapped;
    
    public WrappedReplicationNeighborCollection(System.DirectoryServices.ActiveDirectory.ReplicationNeighborCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationNeighbor Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor neighbor)
    {
        return this._wrapped.Contains(neighbor);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor neighbor)
    {
        return this._wrapped.IndexOf(neighbor);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationNeighbor[] neighbors, int index)
    {
        this._wrapped.CopyTo(neighbors, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationOperation {
    
    System.DateTime TimeEnqueued {
        get;
    }
    
    int OperationNumber {
        get;
    }
    
    int Priority {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationType OperationType {
        get;
    }
    
    string PartitionName {
        get;
    }
    
    string SourceServer {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperation Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationOperation
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationOperation _wrapped;
    
    public WrappedReplicationOperation(System.DirectoryServices.ActiveDirectory.ReplicationOperation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DateTime TimeEnqueued
    {
        get
        {
            return this._wrapped.TimeEnqueued;
        }
    }
    
    public virtual int OperationNumber
    {
        get
        {
            return this._wrapped.OperationNumber;
        }
    }
    
    public virtual int Priority
    {
        get
        {
            return this._wrapped.Priority;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperationType OperationType
    {
        get
        {
            return this._wrapped.OperationType;
        }
    }
    
    public virtual string PartitionName
    {
        get
        {
            return this._wrapped.PartitionName;
        }
    }
    
    public virtual string SourceServer
    {
        get
        {
            return this._wrapped.SourceServer;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationOperationCollection {
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperation Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationOperation operation);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationOperation operation);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationOperation[] operations, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationOperationCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationOperationCollection _wrapped;
    
    public WrappedReplicationOperationCollection(System.DirectoryServices.ActiveDirectory.ReplicationOperationCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperation Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ReplicationOperation operation)
    {
        return this._wrapped.Contains(operation);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ReplicationOperation operation)
    {
        return this._wrapped.IndexOf(operation);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ReplicationOperation[] operations, int index)
    {
        this._wrapped.CopyTo(operations, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IReplicationOperationInformation {
    
    System.DateTime OperationStartTime {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperation CurrentOperation {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationCollection PendingOperations {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedReplicationOperationInformation
{
    
    private System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation _wrapped;
    
    public WrappedReplicationOperationInformation(System.DirectoryServices.ActiveDirectory.ReplicationOperationInformation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DateTime OperationStartTime
    {
        get
        {
            return this._wrapped.OperationStartTime;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperation CurrentOperation
    {
        get
        {
            return this._wrapped.CurrentOperation;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReplicationOperationCollection PendingOperations
    {
        get
        {
            return this._wrapped.PendingOperations;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryInterSiteTransport {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType {
        get;
    }
    
    bool IgnoreReplicationSchedule {
        get;
        set;
    }
    
    bool BridgeAllSiteLinks {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection SiteLinks {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkBridgeCollection SiteLinkBridges {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryInterSiteTransport Wrapped {
        get;
    }
    
    void Save();
    
    System.DirectoryServices.DirectoryEntry GetDirectoryEntry();
    
    void Dispose();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryInterSiteTransport
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryInterSiteTransport _wrapped;
    
    public WrappedActiveDirectoryInterSiteTransport(System.DirectoryServices.ActiveDirectory.ActiveDirectoryInterSiteTransport wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryTransportType TransportType
    {
        get
        {
            return this._wrapped.TransportType;
        }
    }
    
    public virtual bool IgnoreReplicationSchedule
    {
        get
        {
            return this._wrapped.IgnoreReplicationSchedule;
        }
        set
        {
            this._wrapped.IgnoreReplicationSchedule = value;
        }
    }
    
    public virtual bool BridgeAllSiteLinks
    {
        get
        {
            return this._wrapped.BridgeAllSiteLinks;
        }
        set
        {
            this._wrapped.BridgeAllSiteLinks = value;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkCollection SiteLinks
    {
        get
        {
            return this._wrapped.SiteLinks;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ReadOnlySiteLinkBridgeCollection SiteLinkBridges
    {
        get
        {
            return this._wrapped.SiteLinkBridges;
        }
    }
    
    public virtual void Save()
    {
        this._wrapped.Save();
    }
    
    public virtual System.DirectoryServices.DirectoryEntry GetDirectoryEntry()
    {
        return this._wrapped.GetDirectoryEntry();
    }
    
    public virtual void Dispose()
    {
        this._wrapped.Dispose();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IActiveDirectoryRoleCollection {
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole[] roles, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedActiveDirectoryRoleCollection
{
    
    private System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection _wrapped;
    
    public WrappedActiveDirectoryRoleCollection(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRoleCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        return this._wrapped.Contains(role);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole role)
    {
        return this._wrapped.IndexOf(role);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.ActiveDirectoryRole[] roles, int index)
    {
        this._wrapped.CopyTo(roles, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface IAdamRoleCollection {
    
    System.DirectoryServices.ActiveDirectory.AdamRole Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.AdamRoleCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.AdamRole role);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.AdamRole role);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.AdamRole[] roles, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedAdamRoleCollection
{
    
    private System.DirectoryServices.ActiveDirectory.AdamRoleCollection _wrapped;
    
    public WrappedAdamRoleCollection(System.DirectoryServices.ActiveDirectory.AdamRoleCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.AdamRole Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.AdamRole role)
    {
        return this._wrapped.Contains(role);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.AdamRole role)
    {
        return this._wrapped.IndexOf(role);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.AdamRole[] roles, int index)
    {
        this._wrapped.CopyTo(roles, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ITopLevelName {
    
    string Name {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TopLevelNameStatus Status {
        get;
        set;
    }
    
    System.DirectoryServices.ActiveDirectory.TopLevelName Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedTopLevelName
{
    
    private System.DirectoryServices.ActiveDirectory.TopLevelName _wrapped;
    
    public WrappedTopLevelName(System.DirectoryServices.ActiveDirectory.TopLevelName wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string Name
    {
        get
        {
            return this._wrapped.Name;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TopLevelNameStatus Status
    {
        get
        {
            return this._wrapped.Status;
        }
        set
        {
            this._wrapped.Status = value;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ITopLevelNameCollection {
    
    System.DirectoryServices.ActiveDirectory.TopLevelName Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TopLevelNameCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.TopLevelName name);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.TopLevelName name);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.TopLevelName[] names, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedTopLevelNameCollection
{
    
    private System.DirectoryServices.ActiveDirectory.TopLevelNameCollection _wrapped;
    
    public WrappedTopLevelNameCollection(System.DirectoryServices.ActiveDirectory.TopLevelNameCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TopLevelName Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.TopLevelName name)
    {
        return this._wrapped.Contains(name);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.TopLevelName name)
    {
        return this._wrapped.IndexOf(name);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.TopLevelName[] names, int index)
    {
        this._wrapped.CopyTo(names, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ITrustRelationshipInformation {
    
    string SourceName {
        get;
    }
    
    string TargetName {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustType TrustType {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustDirection TrustDirection {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation Wrapped {
        get;
    }
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedTrustRelationshipInformation
{
    
    private System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation _wrapped;
    
    public WrappedTrustRelationshipInformation(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual string SourceName
    {
        get
        {
            return this._wrapped.SourceName;
        }
    }
    
    public virtual string TargetName
    {
        get
        {
            return this._wrapped.TargetName;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustType TrustType
    {
        get
        {
            return this._wrapped.TrustType;
        }
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustDirection TrustDirection
    {
        get
        {
            return this._wrapped.TrustDirection;
        }
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}

internal interface ITrustRelationshipInformationCollection {
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation Item {
        get;
    }
    
    int Count {
        get;
    }
    
    System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection Wrapped {
        get;
    }
    
    bool Contains(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation information);
    
    int IndexOf(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation information);
    
    void CopyTo(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation[] array, int index);
    
    System.Collections.IEnumerator GetEnumerator();
    
    string ToString();
    
    bool Equals(object obj);
    
    int GetHashCode();
    
    System.Type GetType();
}

public partial class WrappedTrustRelationshipInformationCollection
{
    
    private System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection _wrapped;
    
    public WrappedTrustRelationshipInformationCollection(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformationCollection wrapped)
    {
        this._wrapped = wrapped;
    }
    
    public virtual System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation Item
    {
        get
        {
            return this._wrapped.Item;
        }
    }
    
    public virtual int Count
    {
        get
        {
            return this._wrapped.Count;
        }
    }
    
    public virtual bool Contains(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation information)
    {
        return this._wrapped.Contains(information);
    }
    
    public virtual int IndexOf(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation information)
    {
        return this._wrapped.IndexOf(information);
    }
    
    public virtual void CopyTo(System.DirectoryServices.ActiveDirectory.TrustRelationshipInformation[] array, int index)
    {
        this._wrapped.CopyTo(array, index);
    }
    
    public virtual System.Collections.IEnumerator GetEnumerator()
    {
        return this._wrapped.GetEnumerator();
    }
    
    public virtual string ToString()
    {
        return this._wrapped.ToString();
    }
    
    public virtual bool Equals(object obj)
    {
        return this._wrapped.Equals(obj);
    }
    
    public virtual int GetHashCode()
    {
        return this._wrapped.GetHashCode();
    }
    
    public virtual System.Type GetType()
    {
        return this._wrapped.GetType();
    }
}


*/
}