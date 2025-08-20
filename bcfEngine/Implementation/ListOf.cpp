#include "pch.h"
#include "ListOf.h"
#include "Project.h"
#include "Component.h"
#include "Topic.h"

/// <summary>
/// 
/// </summary>
ListOfBCFObjects::~ListOfBCFObjects()
{
    Clean(m_items);
    Clean(m_removed);
}

/// <summary>
/// 
/// </summary>
BCFObject* ListOfBCFObjects::GetAt(uint16_t ind)
{
    if (ind < m_items.size())
        return m_items[ind];
    else
        return NULL;
}

/// <summary>
/// 
/// </summary>
Project& ListOfBCFObjects::Project_()
{ 
    return m_container.Project_(); 
}

/// <summary>
/// 
/// </summary>
bool ListOfBCFObjects::Add(BCFObject* item)
{
    assert(item);
    if (item) {
        m_items.push_back(item);
        return m_container.MarkModified();
    }
    return true;
}

/// <summary>
/// 
/// </summary>
bool ListOfBCFObjects::Remove(BCFObject* item)
{
    auto it = Find(item);

    if (it != m_items.end()) {
        m_removed.push_back(*it);
        m_items.erase(it);
        return m_container.MarkModified();
    }
    else {
        return false;
    }
}

/// <summary>
/// 
/// </summary>
void ListOfBCFObjects::Clean(Items& items)
{
    for (auto item : items) {
        delete item;
    }
    items.clear();
}

/// <summary>
/// 
/// </summary>
ListOfBCFObjects::Iterator ListOfBCFObjects::Find(BCFObject* item)
{
    for (auto it = m_items.begin(); it != m_items.end(); it++) {
        if (*it == item) {
            return it;
        }
    }
    Project_().Log_().add(Log::Level::error, "Item not found in the list");
    return m_items.end();
}

/// <summary>
/// 
/// </summary>
void ListOfBCFObjects::LogDuplicatedGuid(const char* guid)
{
    Project_().Log_().add(Log::Level::error, "Duplicated GUID");
}

/// <summary>
/// 
/// </summary>
SetOfXMLText::SetOfXMLText(Topic& topic) 
    : ListOf<XMLText>(topic) 
    , m_topic(topic)
{
}


/// <summary>
/// 
/// </summary>
Component* ListOfComponents::Add(ViewPoint& viewPoint, const char* ifcGuid, const char* authoringToolId, const char* originatingSystem)
{
    auto comp = new Component(viewPoint, this);

    bool ok = true;
    if (ifcGuid) ok = ok && comp->SetIfcGuid(ifcGuid);
    if (authoringToolId) ok = ok && comp->SetAuthoringToolId(authoringToolId);
    if (originatingSystem) ok = ok && comp->SetOriginatingSystem(originatingSystem);

    if (ok) {
        ListOfBCFObjects::Add(comp);
        return comp;
    }
    else {
        delete comp;
        return NULL;
    }
}

/// <summary>
/// 
/// </summary>
bool SetOfXMLText::Add(const char* val)
{
    if (val && *val) {
        if (!Find(val)) {
            auto txt = new XMLText(m_topic, this);
            txt->string().assign(val);
            return ListOfBCFObjects::Add(txt);
        }
    }
    return false;
}

/// <summary>
/// 
/// </summary>
XMLText* SetOfXMLText::Find(const char* val)
{
    if (val) {
        std::string sval(val);
        for (auto txt : Items()) {
            if (txt->string() == val) {
                return txt;
            }
        }
    }
    return NULL;
}

/// <summary>
/// 
/// </summary>
const char* SetOfXMLText::GetAt(uint16_t ind)
{
    auto txtNext = ListOf::GetAt(ind);

    if (txtNext) {
        return txtNext->string().c_str();
    }
    else {
        return NULL;
    }
}

/// <summary>
/// 
/// </summary>
bool SetOfXMLText::Remove(const char* val)
{
    if (auto txt = Find(val)) {
        return txt->Remove();
    }
    return false;
}
